<template>
  <va-navbar
      color="#282F69"
      class="h-24"
  >
    <template #left>
      <va-navbar-item class="logo navbar__item">
        Not Tomorrow
      </va-navbar-item>
    </template>
    <template #right>
      <va-navbar-item class="navbar__item">
        <router-link
            to="/"
            class="nav-link"
        >
          Главная
        </router-link>
      </va-navbar-item>
      <va-navbar-item class="navbar__item">
        <router-link
            to="/search"
            class="nav-link"
        >
          Поиск работы
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
    </template>
  </va-navbar>
</template>

<script>
import {mapGetters} from "vuex";

export default {
  name: "NavBar",
  computed: {
    ...mapGetters('User',[
        'isAuth'
    ])
  },
  methods: {
    goToAuth(){
      this.$router.push('/auth')
    },
    goToCabinet(){
      this.$router.push('/cabinet')
    }
  }
}
</script>

<style scoped>
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
</style>
