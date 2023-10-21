<template>
  <div id="swiper">
    <div v-if="this.current === vacancies.length">Все вакансии просмотрены</div>
    <VacancyCard v-else :vacancy="vacancies[current]" @:mousedown="onMouseDown" />
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
      const {clientX, clientY} = event;
      this.startPoint = {x: clientX, y: clientY};

      document.addEventListener("mousemove", this.handleMouseMove);
      document.addEventListener("mouseup", this.handleMouseUp);

      this.element.style.transition = "";
      this.element.addEventListener("dragstart", event => {
        event.preventDefault();
      });
    },
    handleMouseMove (event) {
      if (!this.startPoint) return;

      const {clientX, clientY} = event;
      this.offsetX = clientX - this.startPoint.x;
      this.offsetY = clientY - this.startPoint.y;
      // this.element = document.getElementById(this.vacancies[this.current].id);
      this.element.style.transform = `translate(${this.offsetX}px, ${this.offsetY}px`;

      if (Math.abs(this.offsetX) > this.element.clientWidth * 0.7) {
        const direction = this.offsetX > 0 ? 1 : -1;
        if (direction < 0) {
          this.dismiss();
        } else {
          // отклик?
        }
      }
    },
    handleMouseUp () {
      this.startPoint = null;
      document.removeEventListener("mousemove", this.handleMouseMove);
      this.element.style.transition = "transform 0.5s";
      this.element.style.transform = "";
    },
    dismiss () {
      this.startPoint = null;
      document.removeEventListener("mouseup", this.handleMouseUp);
      document.removeEventListener("mousemove", this.handleMouseMove);

      this.element.style.transition = "transform 1s";
      this.element.style.transform = `translate(${-window.innerWidth}px, ${this.offsetY}px`;

      // document.addEventListener("mousemove", this.handleMouseMove);
      // document.addEventListener("mouseup", this.handleMouseUp);

      setTimeout(() => {
        this.current++;
        if (this.current === this.vacancies.length) {
          return;
        }

        this.startPoint = null;
        // document.removeEventListener("mousemove", this.handleMouseMove);
        this.element.style.transition = "";
        this.element.style.transform = "";

        this.element.style.opacity = 1;
        this.element.style.transition = "opacity 10s";

        // this.element.style.opacity

        // console.log(this.vacancies[this.current].id)
        // console.log(this.element);
      }, 1000);
    },
  }
}
</script>

<style scoped>
#swiper {
  height: 50vh;
  //border: 1px solid black;
}
</style>