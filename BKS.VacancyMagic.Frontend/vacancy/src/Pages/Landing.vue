<template>
   <div class="landing-page">
       <div class="new-navbar">
           <div class="logo">
               Not tomorrow
           </div>
<!--           <div class="join-link" @click="">-->
<!--               Найти работу-->
<!--           </div>-->
       </div>
       <div class="page">
           <div class="content">

               <div class="center-flex">
                   <span id="typed"></span>
               </div>
               <div id="typed-strings">
                   <span>Как же мне найти работу?</span>
                   <span>Хочу мало работать и много зарабатывать</span>
               </div>

                <div class="super-action">
                    <va-button
                        @click="goToAuth()"
                    >
                        Найти работу!
                    </va-button>
                </div>

               <div class="serviceCardList">
                   <div v-for="service in services">
                       <ServiceCard :service="service" />
                   </div>
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
          id: "sj",
          name: "Superjob",
          logoUrl: '/superjob_logo_180.png',
          color: "#00aa87",
          functions: [
              {
                  name: "Поиск",
                  implemented: true,
              },
              {
                  name: "Отклик",
                  implemented: true,
              },
              {
                  name: "Мониторинг",
                  implemented: true,
              },
              {
                  name: "Оповещения",
                  implemented: true,
              }
          ],
        },
        {
          id: "hh",
          name: "HeadHunter",
          logoUrl: '/hhLogo.png',
          color: "#78a1b5",
          functions: [
              {
                  name: "Поиск",
                  implemented: true,
              },
              {
                  name: "Отклик",
                  implemented: false,
              },
              {
                  name: "Мониторинг",
                  implemented: false,
              },
              {
                  name: "Оповещения",
                  implemented: false,
              }
          ]
        },
        {
          id: "hb",
          name: "Хабр Карьера",
          logoUrl: '/habr_logo.jpg',
          color: "red",
          functions: [
            {
              name: "Поиск",
              implemented: false,
            },
            {
              name: "Отклик",
              implemented: false,
            },
            {
              name: "Мониторинг",
              implemented: false,
            },
            {
              name: "Оповещения",
              implemented: false,
            }
          ]
        },
      ],
    }
  },
    mounted() {
        let typed = new Typed('#typed', { // Тут id того блока, в которм будет анимация
            stringsElement: '#typed-strings', // Тут id блока из которого берем строки для анимации
            typeSpeed: 100, // Скорость печати
            startDelay: 500, // Задержка перед стартом анимации
            backSpeed: 50, // Скорость удаления
            loop: true // Указываем, повторять ли анимацию
        });
    },
    methods: {
        goToAuth(){
            this.$router.push('/auth')
        }
    }
}
</script>

<style scoped>
.center-flex {
    display: flex;
    flex-direction: row;
    margin: 2rem 0;
    padding: 2rem 0;
    justify-content: center;
    height: 90px;
}
.join-link {
    cursor: pointer;
    text-decoration: underline;
}
.landing-page {
    display: flex;
    flex-direction: column;
    width: 100%;
    min-height: 100vh;
    background-color: #f8f8f8;
}
.new-navbar {
    padding: 1rem;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
}
.flex-row {
    display: flex;
    flex-direction: row;
}
.super-action {
    display: flex;
    justify-content: center;
    align-items: center;
    margin: 2rem 0;
}
#typed-strings {
  display: none;
}
.page {
  padding-top: 2rem;
  width: 100%;
  display: flex;
  flex-direction: column;
    flex-grow: 1;
    align-items: end;
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
