<template>
  <va-card
    :id="vacancy.id"
    class="card"
  >
    <div class="title" role="heading">
      {{vacancy.title}}
      <div class="rightTitleBox">
        <div>
          от {{vacancy.employer}}
        </div>
        <div>
          <va-image
            class="service-logo"
            fit="contain"
            :src="vacancy.serviceLogoUrl"
          />
        </div>
      </div>
    </div>
    <va-card-content class="content">
      <TagsContainer :tags="vacancy.tags" />
      <div v-html="vacancy.description" class="vacancy-description">
      </div>
    </va-card-content>
  </va-card>
</template>

<script>
import TagsContainer from "./TagsContainer.vue";

export default {
  components: {TagsContainer},
  props: {
    vacancy: {},
  },
}
</script>

<style scoped>
.vacancy-description {
  overflow: hidden;
  text-overflow: ellipsis;
  display: -webkit-box;
  -webkit-line-clamp: 6;
  -webkit-box-orient: vertical;
}
.card {
  width: 100%;
  border: 2px solid var(--va-background-border);
  border-radius: 8px;
  max-width: 600px;
}
.title {
  display: flex;
  flex-wrap: wrap;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;

  font-size: 1.5rem;
  font-weight: bold;
  padding: 1rem 1.5rem 0 1.5rem;
}
.rightTitleBox {
  display: flex;
  flex-wrap: wrap;
  flex-direction: row;
  gap: 1rem;
  align-items: center;
}
.service-logo {
  width: 1.6rem;
  height: 1.6rem;
}
.content {
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
}

</style>