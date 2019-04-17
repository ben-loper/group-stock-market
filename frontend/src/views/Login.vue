<template>
<div>
  <default-layout></default-layout>
  <div id="login" class="text-center">
    <form class="form-signin" @submit.prevent="login">
      <h1 class="h3 mb-3 font-weight-normal">Please Sign In</h1>
      <div class="alert alert-danger" role="alert" v-if="invalidCredentials">
        Invalid username and password!
      </div>
      <div class="alert alert-success" role="alert" v-if="this.$route.query.registration">
        Thank you for registering, please sign in.
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
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <router-link :to="{ name: 'register' }" style="color: #611aa6;">
        Need an account?
      </router-link>
      <button class="btn btn-lg btn-primary btn-block" type="submit" style="background-color: #611aa6;">
        Sign in
      </button>
    </form>
  </div>
</div>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';
import auth from '../auth';

export default {
  name: 'Login',
  components: {
    DefaultLayout,
  },
  data() {
    return {
      user: {
        username: '',
        password: '',
      },
      invalidCredentials: false,
    };
  },
  methods: {
    login() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/login`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.user),
      })
        .then((response) => {
          if (response.ok) {
            return response.text();
          } else {
            this.invalidCredentials = true;
          }
        })
        .then((token) => {
          if (token != undefined) {
            if (token.includes('"')) {
              token = token.replace(/"/g, '');
            }
            auth.saveToken(token);
            this.$router.push('/portfolio');
          }
        })
        .catch((err) => console.error(err));
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
  background-color: #f5f5f5 !important;
  /* background-image: url("../assets/wallstreet-bull.jpg");
  background-repeat: no-repeat;
  background-size: cover;
  background-position: 5%; */
}
#login {
  height: 100%;
  width: 27%;
  margin-left: 37%;
  margin-top: 9%;
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

.form-signin {
  width: 100%;
  max-width: 330px;
  padding: 15px;
  margin: auto;
}

.logo {
  width: 55%;
  border-radius: 5px;
  margin-bottom: 4%;
}

.form-signin .form-control {
  position: relative;
  box-sizing: border-box;
  height: auto;
  padding: 10px;
  font-size: 16px;
}
.form-signin .form-control:focus {
  z-index: 2;
  border-color: #611aa6;
  box-shadow: 0 0 10px #611aa6;
}
.form-signin input[type='text'] {
  margin-bottom: 10px;
  border-bottom-right-radius: 0;
  border-bottom-left-radius: 0;
}
.form-signin input[type='password'] {
  margin-bottom: 10px;
  border-top-left-radius: 0;
  border-top-right-radius: 0;
}
</style>
