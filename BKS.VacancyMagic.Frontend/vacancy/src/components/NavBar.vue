<template>
  <va-navbar
      color="#282F69"
      class="h-24"
  >
    <template #left>
      <va-navbar-item class="logo navbar__item" @click="goToMain()">
        Not Tomorrow
      </va-navbar-item>
    </template>
    <template #right>
      <div v-if="!isMobile" class="right-block">
<!--          <va-navbar-item class="navbar__item">-->
<!--              <router-link-->
<!--                  to="/"-->
<!--                  class="nav-link"-->
<!--              >-->
<!--                  Главная-->
<!--              </router-link>-->
<!--          </va-navbar-item>-->
          <va-navbar-item class="navbar__item">
              <router-link
                to="/search"
                class="nav-link"
              >
                  Найти работу
              </router-link>
          </va-navbar-item>
          <va-navbar-item class="navbar__item">
              <router-link
                to="/reply"
                class="nav-link"
              >
                  Отклики
              </router-link>
          </va-navbar-item>
          <va-navbar-item class="navbar__item">
              <div class="user-info-block" v-if="isAuth">
                  <va-icon name="person" />
                  <div class="flex-row">
                      <div @click="goToCabinet">
                          username surname
                      </div>
                      <va-button
                              color="danger"
                      >
                          Выйти
                      </va-button>
                  </div>
              </div>
              <div
                      v-else
              >
                  <va-button
                          @click="goToAuth"
                  >
                      Войти
                  </va-button>
              </div>
          </va-navbar-item>
      </div>
      <div v-else>
          <va-button
            icon="menu"
            @click="showSidebar=true"
          />
      </div>
    </template>
  </va-navbar>
    <VaSidebar v-model="showSidebar" class="right-navbar">
        <VaSidebarItem @click="showSidebar=false">
            <VaSidebarItemContent>
                <VaSidebarItemTitle>
                    <VaIcon name="close" />
                    Закрыть
                </VaSidebarItemTitle>
            </VaSidebarItemContent>
        </VaSidebarItem>
        <VaSidebarItem>
            <VaSidebarItemContent>
                <router-link
                        to="/"
                        class="nav-link-sidebar"
                >
                    Главная
                </router-link>
            </VaSidebarItemContent>
        </VaSidebarItem>
        <VaSidebarItem>
            <VaSidebarItemContent>
                <router-link
                    to="/search"
                    class="nav-link-sidebar"
                >
                    Поиск работы
                </router-link>
            </VaSidebarItemContent>
        </VaSidebarItem>
        <VaSidebarItem>
            <VaSidebarItemContent>
                <router-link
                    to="/reply"
                    class="nav-link-sidebar"
                >
                    Отклики
                </router-link>
            </VaSidebarItemContent>
        </VaSidebarItem>
        <VaSidebarItem>
            <VaSidebarItemContent>
                <div class="user-info-block" v-if="isAuth">
                    <va-icon name="person" />
                    <div class="flex-row">
                        <div @click="goToCabinet">
                            username surname
                        </div>
                        <va-button
                                color="danger"
                        >
                            Выйти
                        </va-button>
                    </div>
                </div>
                <div
                        v-else
                >
                    <va-button
                            @click="goToAuth"
                    >
                        Войти
                    </va-button>
                </div>
            </VaSidebarItemContent>
        </VaSidebarItem>
    </VaSidebar>
</template>

<script>
import {mapGetters, mapMutations} from "vuex";

export default {
  name: "NavBar",
  computed: {
    ...mapGetters('User',[
        'isAuth'
    ])
  },
    watch: {
      isMobile:function (newValue){
          this.changeIsMobile(newValue);
      }
    },
  data(){
    return {
      showSidebar:false,
      isMobile:false,
      mql:null,
      onChange:null,
    }
  },
    created() {
        this.mql = window.matchMedia('(max-width: 860px)');
        this.onChange = () => this.isMobile = this.mql.matches;
        this.onChange();
        this.mql.addEventListener('change', this.onChange);
    },
    unmounted() {
        this.mql.removeEventListener('change', this.onChange);
    },
    methods: {
      ...mapMutations('Style',[
          'changeIsMobile'
      ]),
      goToAuth(){
        this.$router.push('/auth')
      },
      goToCabinet(){
        this.$router.push('/cabinet')
      },
      goToMain(){
        this.$router.push('/')
      }
  }
}
</script>

<style scoped>
.logo {
    cursor: pointer;
}
.nav-link-sidebar {
    color: #181818;
}
.flex-row {
  display: flex;
  gap: 1rem;
  align-items: center;
}
.navbar__item {
  display: flex;
  align-items: center;
}
.user-info-block {
  cursor: pointer;
  display:flex;
  align-items: center;
  flex-direction: row;
  gap: 0.25rem;
}
.nav-link {
  cursor: pointer;
  color: white;
}
.right-navbar {
  position: absolute;
  right: 0;
}
.right-block {
    display: flex;
    gap: 0.75rem;
}
</style>
