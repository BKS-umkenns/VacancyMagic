<template>
  <div class="auth-page">
    <va-form
        class="auth-form-container"
        @submit.prevent="action"
        ref="formRef"
    >
      <va-input
          v-model="email"
          label="Email"
          type="email"
          :rules="[
            (value) => (value && value.length > 0) || 'Email обязателен',
            (value) => validateEmail(value) || 'Некоректный Email'
          ]"
      />

      <va-input
          v-model="password"
          type="password"
          label="Пароль"
          :rules="[
              (val)=>(val.length>0) || 'Пароль обязателен'
          ]"
      />

      <va-input
        v-if="!isLogin"
        v-model="name"
        label="Имя"
        :rules="[
              (val)=>(val.length>0) || 'Имя обязателеньно'
          ]"
      />

      <va-input
        v-if="!isLogin"
        v-model="lastname"
        label="Фамилия"
        :rules="[
            (val)=>(val.length>0) || 'Фамилия обязателеньна'
        ]"
      />

      <va-input
        v-if="!isLogin"
        v-model="middlename"
        label="Отчество"
      />

      <va-button
          type="submit"
          class="mt-3"
          :disabled="!isValidForm"
          @click="action"
      >
        {{isLogin?'Войти':'Зарегестрироваться'}}
      </va-button>

      <div class="change-mode-row">
        <div
          @click="changeMode()"
        >
          {{isLogin?'Зарегестрироваться':'Войти'}}
        </div>
      </div>
    </va-form>
  </div>
</template>

<script>
export default {
  data(){
    return {
      isLogin:false,
      email:'',
      password:'',
      name:'',
      lastname:'',
      middlename:'',
    }
  },
  methods: {
    changeMode(){
      this.isLogin = !this.isLogin;
    },
    action(){
      console.log('action')
    },
    validateEmail(email){
      return String(email)
          .toLowerCase()
          .match(
              /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
          );
    },
    isValidForm() {
      if(!this.$refs.formRef) return false;
      console.log(this.$refs.formRef.isValid)
      return this.$refs.formRef.isValid;
    },
  }
}
</script>

<style scoped>
.auth-page {
  flex-grow: 1;
  display: flex;
  flex-direction: column;
}
.auth-form-container {
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
}
.change-mode-row {
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 0.8rem;
  text-decoration: underline;
  cursor: pointer;
}
</style>