<script>
import NavBar from "../components/NavBar.vue";
import {mapGetters} from "vuex";
import ReplyCard from "../components/ReplyCard.vue";

export default {
  components: {
      ReplyCard,
    NavBar
  },
  computed: {
    ...mapGetters('Reply',[
        'items',
        'statuses',
        'services'
    ])
  },
  data(){
    return {
      columns: [
        {
          key: "createdAt",
          name: "createdAt",
          label: "Время"
        },
        {
          key: "serviceId",
          name: "serviceId",
          label: "Сервис"
        },
        {
          key: "employer",
          name: "employer",
          label: "Работадатель"
        },
        {
          key: "vacancyName",
          name: "vacancyName",
          label: "Название"
        },
        {
          key: "description",
          name: "description",
          label: "Описание"
        },
        {
          key: "status",
          name: "status",
          label: "Статус"
        },
        {
          key: "id",
          name: "id",
          label: " "
        },
      ]
    }
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

<template>
  <NavBar />
  <div class="reply-page">
    <div class="info-block">
      На данной странице вы можете отслеживать свои отклики на разных сервисах, как только проихойдет изменения мы пришлем вам оповещение
    </div>

    <div class="replies-list">
        <ReplyCard
          v-for="reply in items"
          :key="reply.id"
          :reply="reply"
        />
    </div>
  </div>
</template>

<style scoped>
.info-block {
  padding: 2rem;
}
.reply-page {
  display: flex;
  flex-direction: column;
}
.replies-list {
  display: flex;
  flex-direction: column;
  padding: 2rem;
  width: 100%;
}
</style>