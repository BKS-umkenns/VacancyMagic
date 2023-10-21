<template>
  <div class="reply-container">
      <div class="header">
          <div class="service">
              <va-image
                  class="service-logo"
                  fit="contain"
                  :src="getServiceInfo(reply.serviceId).logo"
              />
          </div>
          <div class="title-data-block">
              <div class="title">
                  {{reply.vacancyName}}

                  <va-button
                      :rounded="false"
                      size="small"
                      @click="openServiceLink(value)"
                  >
                      Открыть
                  </va-button>
              </div>
              <div class="data">
                {{reply.createdAt}}
              </div>
          </div>
          <div class="flex-row">
              <div class="employer">
                  {{reply.employer}}
              </div>
              <div class="status-block">
                  <va-chip
                      size="small"
                      :color="getStatusInfo(reply.status).color"
                  >
                      {{ getStatusInfo(reply.status).title }}
                  </va-chip>
              </div>
          </div>
      </div>
      <div class="more-info">

      </div>
  </div>
</template>

<script>
import {mapActions, mapGetters} from "vuex";

export default {
    props:[
        'reply'
    ],
    computed: {
        ...mapGetters('Reply',[
            'services',
            'statuses'
        ]),
    },
    methods: {
        getStatusInfo(id){
            return this.statuses.find(el=>el.id == id);
        },
        getServiceInfo(id){
            return this.services.find(el=>el.id == id);
        },
        openServiceLink(id){
            console.log('open service link'+id)
        }
    }
}
</script>

<style scoped>
.flex-row {
    display: flex;
    flex-direction: row;
    gap: 0.5rem;
    flex-wrap: wrap;
    align-items: center;
}
.data {
    font-size: 0.8rem;
    color: gray;
}
.title-data-block {
    flex-grow: 1;
}
.header {
    display: flex;
    flex-wrap: wrap;
    flex-direction: row;
    justify-content: space-between;
    gap: 1rem;
    align-items: center;
    cursor: pointer;
    border: var(--va-background-border) 2px solid;
    flex-grow: 1;
    background-color: var(--va-background-element);
    padding: 0.5rem;
}
.reply-container {
    display: flex;
    flex-direction: column;
    gap: 0.25rem;
}
.service-logo {
    width: 50px;
    height: 50px;
}
.status-block {
    width: 10rem;
    align-items: center;
    display: flex;
    justify-content: center;
}
</style>