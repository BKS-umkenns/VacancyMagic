<template>
  <NavBar />
  <div class="page">
    <div class="content">
      <div class="serviceCardList">
        <div v-for="service in services">
          <ServiceCard :service="service" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import NavBar from "../components/NavBar.vue";
import ServiceCard from "../components/ServiceCard.vue";

export default {
  name: "Home",
  components: {ServiceCard, NavBar},
  data() {
    return {
      services: [
        {
          id: "hh",
          name: "HH",
          logoUrl: '/hhLogo.png',
          color: "red",
          functions: [
            {
              name: "Поиск работы",
              implemented: true,
            },
            {
              name: "Отслеживание откликов",
              implemented: true,
            }
          ],
        },
        {
          id: "hh",
          name: "HH",
          logoUrl: '/hhLogo.png',
          color: "red",
          functions: [
            {
              name: "Поиск работы",
              implemented: true,
            },
            {
              name: "Отслеживание откликов",
              implemented: false,
            }
          ]
        },
        {
          id: "hh",
          name: "HH",
          logoUrl: '/hhLogo.png',
          color: "red",
          functions: [
            {
              name: "Поиск работы",
              implemented: true,
            },
            {
              name: "Отслеживание откликов",
              implemented: false,
            }
          ]
        },
      ],
    }
  },
}
</script>

<style scoped>
.page {
  background-color: #f8f8f8;

  padding-top: 2rem;

  height: 100vh;
  width: 100%;

  display: flex;
  flex-direction: column;
}
.content {
  width: 100%;
}
.serviceCardList {
  width: 70%;

  margin: auto;

  display: grid;
  grid-template-columns: repeat(3, minmax(0, 1fr));
  gap: 2rem;
}
@media screen and (max-width: 65rem){
  .serviceCardList {
    grid-template-columns: repeat(1, minmax(0, 1fr));
  }
}
</style>
