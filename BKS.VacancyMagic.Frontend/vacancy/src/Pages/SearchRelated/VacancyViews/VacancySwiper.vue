<template>
  <div id="swiper">
    <div v-if="this.current === vacancies.length">Все вакансии просмотрены</div>
    <VacancyCard v-else :vacancy="vacancies[current]" @:mousedown="onMouseDown" @:touchstart="onMouseDown"/>
  </div>
</template>

<script>
import VacancyCard from "../../../components/VacancyCard.vue";
import {mapGetters} from "vuex";

export default {
  name: "Swiper",
  components: {VacancyCard},

  data() {
    return {
      startPoint: null,
      offsetX: null,
      offsetY: null,
      current: 0,
      element: null,
    }
  },
  computed: {
    ...mapGetters('Search',[
      'vacancies'
    ]),
  },
  mounted() {
    this.element = document.getElementById(this.vacancies[this.current].id);
  },
  methods: {
    onMouseDown (event) {
      let clientX;
      if (event instanceof TouchEvent) {
        clientX = event.touches[0].clientX;

        document.addEventListener("touchmove", this.handleMouseMove);
        document.addEventListener("touchend", this.handleMouseUp);
      } else {
        clientX = event.clientX;

        document.addEventListener("mousemove", this.handleMouseMove);
        document.addEventListener("mouseup", this.handleMouseUp);
      }
      this.startPoint = {x: clientX};

      this.element.style.transition = "";
      this.element.addEventListener("dragstart", event => {
        event.preventDefault();
      });
    },
    handleMouseMove (event) {
      if (!this.startPoint) return;
      let clientX;
      let scale;
      if (event instanceof TouchEvent) {
        clientX = event.touches[0].clientX;
        scale = 0.3;
      } else {
        clientX = event.clientX;
        scale = 0.7;
      }
      this.offsetX = clientX - this.startPoint.x;
      this.element.style.transform = `translate(${this.offsetX}px`;
      if (Math.abs(this.offsetX) > this.element.clientWidth * scale) {

        const direction = this.offsetX > 0 ? 1 : -1;
        if (direction < 0) {
          this.dismiss();
        } else {
          // отклик?
        }
      }
    },
    handleMouseUp (event) {
      this.startPoint = null;

      let scale;
      if (event instanceof TouchEvent) {
        document.removeEventListener("touchmove", this.handleMouseMove);
        scale = 0.3;
      } else {
        document.removeEventListener("mousemove", this.handleMouseMove);
        scale = 0.7;
      }
      if (Math.abs(this.offsetX) <= this.element.clientWidth * scale) {
        this.element.style.transition = "transform 0.5s";
        this.element.style.transform = "";
      }

    },
    dismiss (event) {
      this.startPoint = null;

      let timeout;
      if (event instanceof TouchEvent) {
        document.removeEventListener("touchend", this.handleMouseUp);
        document.removeEventListener("touchmove", this.handleMouseMove);
        timeout = 1000;
      } else {
        document.removeEventListener("mouseup", this.handleMouseUp);
        document.removeEventListener("mousemove", this.handleMouseMove);
        timeout = 1000;
      }
      this.element.style.transition = `transform ${timeout / 1000}s`;
      this.element.style.transform = `translate(${-window.innerWidth}px`;

      setTimeout(() => {
        this.current++;
        if (this.current === this.vacancies.length) {
          return;
        }

        this.startPoint = null;

        this.element.style.transition = "";
        this.element.style.transform = "";

      }, timeout);
    },
  }
}
</script>

<style scoped>
#swiper {
  height: fit-content;
  width: 80%;
  margin: auto;
}
</style>