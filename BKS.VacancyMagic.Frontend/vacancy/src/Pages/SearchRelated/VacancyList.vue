<template>
  <div class="vacancy-list-container">
    <div class="description-text">
      Мы подобрали вакансии согласно Вашим критериям
    </div>

    <div class="mode-switcher">
      <va-button-toggle
          v-model="selectedViewMode"
          preset="secondary"
          border-color="primary"
          :options="modes"
      />
    </div>

    <div class="presentation-container">
      <VacanciesTable
        v-if="selectedViewMode === 0"
      />
      <VacancySwiper v-else/>
    </div>
  </div>
</template>

<script>
import VacanciesTable from "./VacancyViews/VacanciesTable.vue";
import VacancySwiper from "./VacancyViews/VacancySwiper.vue";
import {mapGetters} from "vuex";

export default {
  components: {VacancySwiper, VacanciesTable},
    computed: {
      ...mapGetters('Style',[
          'isMobile'
      ])
    },
    mounted() {
      if(this.isMobile){
          this.selectedViewMode = 1;
      }
    },
    data(){
    return {
      selectedViewMode:0,
      modes:[
        { label: "Таблица", value: 0 },
        { label: "Tinder?", value: 1 },
      ]
    }
  }
}
</script>

<style scoped>
.vacancy-list-container {
  width: 100%;
  display: flex;
  flex-direction: column;
  gap: 1rem;
}

.presentation-container {
  display: flex;
  flex-grow: 1;
}
.mode-switcher {
  display: flex;
  flex-direction: row;
  justify-content: end;
  flex-grow: 1;
}
</style>