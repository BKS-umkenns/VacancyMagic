<script>
import NavBar from "../components/NavBar.vue";

export default {
  components: {
    NavBar
  },
  data(){
    return {
      items: [
        {
          id:1,
          createdAt:'2023',
          serviceId:'hh',
          employer:'Яндекс',
          vacancyName:'Главный тута',
          description:'Ответсвенная должность, с которой вы раскроете свои таланты и тд и тп',
          status: 1
        },
        {
          id:2,
          createdAt:'2022',
          serviceId:'sj',
          employer:'ИП Иванов',
          vacancyName:'Уборщик',
          description:'!!! ТОЛЬКО ДЛЯ ОТВЕТСВЕННЫХ !!!',
          status:2
        }
      ],
      statuses: [
        {
          id:1,
          color:'warning',
          title:'Отправлено'
        },
        {
          id:2,
          color:'success',
          title:'Собеседование'
        }
      ],
      companies: [
        {
          id: 'hh',
          logo:'/hhLogo.png'
        },
        {
          id: 'sj',
          logo:'/SuperJobLogo.png'
        }
      ],
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
      return this.companies.find(el=>el.id == id);
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
    <div>
      <va-data-table
          :items="items"
          :columns="columns"
      >
        <template #cell(serviceId)="{ value }">
          <va-image
            fit="contain"
            :src="getServiceInfo(value).logo"
          />
        </template>

        <template #cell(vacancyName)="{ value,rowData }">
          <span
              class="vacancy_link"
              @click="openServiceLink(rowData.id)"
          >
            {{value}}
          </span>
        </template>
        <template #cell(status)="{ value }">
          <va-chip
            size="small"
            :color="getStatusInfo(value).color"
          >
            {{ getStatusInfo(value).title }}
          </va-chip>
        </template>
        <template #cell(id)="{ value }">
          <va-button
              :rounded="false"
              @click="openServiceLink(value)"
          >
            Открыть
          </va-button>
        </template>
      </va-data-table>
    </div>
  </div>
</template>

<style scoped>
.vacancy_link {
  text-decoration: underline;
  cursor: pointer;
}
.info-block {
  padding: 2rem;
}
.reply-page {
  display: flex;
  flex-direction: column;
  gap: 2rem;
}
</style>