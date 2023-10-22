<template>
  <div class="prompt-tab">
    <div>
      Опишите вакансию своей мечты
    </div>
    <div>
      <va-textarea
        class="textarea"
        ref="prompt"
        v-model="inputted"
        :max-length="125"
        :max-rows="5"
        placeholder="Я хочу много денег и мало работать..."
        :rules="[
          (v) => v && v.length < 125 || 'Лимит на 125 символов',
        ]"
      />
    </div>
  </div>
</template>

<script>

import {mapGetters, mapMutations} from "vuex";

export default {
  computed: {
    ...mapGetters('Search',[
        'searchState'
    ]),
    inputted: {
      get(){
        return this.searchState.actualPrompt;
      },
      set(newValue){
        this.changeState({
          actualPrompt: newValue
        })
      }
    }
  },
  methods: {
    ...mapMutations('Search',[
        'changeState'
    ]),
  }
}
</script>

<style scoped>
.prompt-tab {
  display: flex;
  flex-direction: column;
  gap: 0.25rem;
}
.textarea {
  min-width: 300px;
}
</style>