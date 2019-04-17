<template>
<div>
  <default-layout></default-layout>
  <div id="register" class="text-center">
    <form class="form-register" @submit.prevent="register">
      <h1 class="h3 mb-3 font-weight-normal">Create Account</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        There were problems registering this user.
      </div>
      <label for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <label for="firstName" class="sr-only">First Name</label>
      <input
        type="text"
        id="firstName"
        class="form-control"
        placeholder="First Name"
        v-model="user.firstName"
        required
        autofocus
      />
      <label for="lastName" class="sr-only">Last Name</label>
      <input
        type="text"
        id="lastName"
        class="form-control"
        placeholder="Last Name"
        v-model="user.lastName"
        required
        autofocus
      />
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <input
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      <router-link :to="{ name: 'login' }" style="color: #611aa6;">
        Have an account?
      </router-link>
      <button class="btn btn-lg btn-primary btn-block" type="submit" style="background-color: #611aa6;">
        Create Account
      </button>
    </form>
  </div>
</div>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';

export default {
  name: 'Register',
  components: {
        DefaultLayout,
  },
  data() {
    return {
      user: {
        username: '',
        firstName: '',
        lastName: '',
        password: '',
        confirmPassword: '',
        role: 'user',
      },
      registrationErrors: false,
    };
  },
  methods: {
    register() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/register`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.user),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/login', query: { registration: 'success' } });
          } else {
            this.registrationErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
  },
};
</script>

<style>
html,
body {
  height: 100%;
}
#app {
  height: 100%;
  /* background-image: url("../assets/wallstreet-bull.jpg");
  background-repeat: no-repeat;
  background-size: cover;
  background-position: 5%; */
}
#register {
  height: 100%;
  width: 27%;
  margin-left: 37%;
  margin-top: 3%;
  display: -ms-flexbox;
  display: flex;
  -ms-flex-align: center;
  align-items: center;
  padding-top: 7px;
  padding-bottom: 10px;
  background-color: #f5f5f5;
  font-family: 'Roboto Condensed', sans-serif;
  border-radius: 5px;
}

form {
  text-align: center;
}

.form-register {
  width: 100%;
  max-width: 330px;
  padding: 15px;
  margin: auto;
}

.form-register .form-control {
  position: relative;
  box-sizing: border-box;
  height: auto;
  padding: 10px;
  font-size: 16px;
}
.form-register .form-control:focus {
  z-index: 2;
  border-color: #611aa6;
  box-shadow: 0 0 10px #611aa6;
}
.form-register input[type='text'] {
  margin-bottom: 10px;
  border-bottom-right-radius: 0;
  border-bottom-left-radius: 0;
}
.form-register input[type='password'] {
  margin-bottom: 10px;
  border-top-left-radius: 0;
  border-top-right-radius: 0;
}
</style>
