<script>
import NavBar from "../components/NavBar.vue";
import AiPromtStep from "./SearchRelated/AiPromtStep.vue";
import ConfirmFilters from "./SearchRelated/ConfirmFilters.vue";
import VacancyList from "./SearchRelated/VacancyList.vue";

export default {
  components: {
    VacancyList,
    ConfirmFilters,
    AiPromtStep,
    NavBar
  },
  watch: {
    actualStep:function (newValue){
      if(newValue === 3){
        this.$router.push('/reply');
      }
    }
  },
  data(){
    return {
      actualStep:0,
      steps: [
        { label: 'Запрос', icon: 'list' },
        { label: 'Фильтры', icon: 'check_box' },
        { label: 'Вакансии', icon: 'payments' },
        { label: 'Отклики', icon: 'done_all' },
      ]
    }
  }
}
</script>

<template>
  <NavBar />
  <va-stepper
      v-model="actualStep"
      :steps="steps"
      controlsHidden
  >
    <template #step-content-0>
      <AiPromtStep
        ref="aiPromt"
      />
    </template>
    <template #step-content-1>
      <ConfirmFilters
      />
    </template>
    <template #step-content-2>
      <VacancyList
      />
    </template>
    <template #step-content-3>
      NEVER BE HERE (we redirect to reply route instead)
    </template>

    <template #controls="{ nextStep, prevStep, step }">
      <va-button @click="prevStep()" :disabled="step.icon === 'list'">Назад</va-button>
      <va-button @click="nextStep()">Дальше</va-button>
    </template>
  </va-stepper>
</template>

<style scoped>

</style>