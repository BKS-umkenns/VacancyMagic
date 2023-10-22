<template>
  <div class="collapse-container">
    <va-collapse
        class="collapse"
        :header="vac.title"
        solid
        v-for="vac in vacancies"
    >
      <template #header="{ value, attrs, iconAttrs, text }">
        <div
            v-bind="attrs"
            class="collapse-header"
        >
          <va-icon
              name="va-arrow-down"
              :class="value ? '' : 'rotate-[-90deg]'"
              v-bind="iconAttrs"
          />

          <div class="flex-grow">
            {{ text }}
          </div>

          <div>
            от {{vac.employer}}
          </div>
          <div>
            <va-image
              class="service-logo"
              fit="contain"
              :src="vac.serviceLogoUrl"
            />
          </div>
          <div>
            <va-button
              @click.stop="replyMethod(vac.id)"
            >
              Откликнуться
            </va-button>
          </div>
        </div>

      </template>

      <template #body>
        <div class="full-description">
          <TagsContainer :tags="vac.tags" />
          <div v-html="vac.description">
          </div>

        </div>
      </template>
    </va-collapse>
  </div>
</template>

<script>
import {mapActions, mapGetters, mapMutations} from "vuex";
import TagsContainer from "../../../components/TagsContainer.vue";
export default {
  components: {TagsContainer},
  computed: {
    ...mapGetters('Search',[
        'vacancies'
    ]),
  },
  methods: {
    ...mapMutations('Search',[
       'removeVac'
    ]),
    replyMethod(id){
      this.removeVac(id);
      this.reply(id)
    },
    ...mapActions('Reply',[
        'reply'
    ]),
  }
}
</script>

<style scoped>
.collapse-container {
  width: 100%;
  flex-grow: 1;
  height: 60vh;
  overflow: auto;
}
.flex-grow {
  flex-grow: 1;
}
.collapse {
  min-width: 98%;
  flex-grow: 1;
}
.collapse-header {
  display: flex;
  flex-wrap: wrap;
  flex-direction: row;
  gap: 1rem;
  align-items: center;
  cursor: pointer;
  border: var(--va-background-border) 2px solid;
  flex-grow: 1;
  background-color: var(--va-background-element);
  padding: 0.5rem;
}
.service-logo {
  width: 1.6rem;
  height: 1.6rem;
}
.full-description {
  padding: 1rem;
  border: var(--va-background-border) 2px solid;
  border-top: 0;
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
  height: 50vh;
}
</style>