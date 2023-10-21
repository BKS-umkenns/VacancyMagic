<template>
  <div class="promt-tab">
    <div>
      Опишите вакансию своей мечты
    </div>
    <div>
      <va-textarea
          class="textarea"
        v-model="inputed"
        autosize
        :max-rows="5"
        placeholder="Я хочу много денег и мало работать..."
      />
    </div>
  </div>
</template>

<script>

export default {
  data(){
    return {
      inputed:''
    }
  }
}
</script>

<style scoped>
.promt-tab {
  display: flex;
  flex-direction: column;
  gap: 0.25rem;
}
.textarea {
  min-width: 400px;
}
</style>