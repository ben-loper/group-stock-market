<template>
  <nav class="navbar navbar-expand navbar-dark">
    <router-link to="/" class="navbar-brand">
      <img src="../assets/Stockr-logo-nav.png" alt width="140" />
      
    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#te-snippets-navbar"
      aria-controls="te-snippets-navbar"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="te-snippets-navbar">
      <ul class="navbar-nav mr-auto">
        <router-link tag="li" class="nav-item" to="/portfolio" active-class="active" exact>
          <a class="nav-link">Dashboard</a>
        </router-link>
        <router-link tag="li" class="nav-item" to="/about" active-class="active">
          <a class="nav-link">About</a>
        </router-link>
      </ul>
    </div>
    <div class="navbar-collapse collapse">
      <ul class="navbar-nav ml-auto">
        <li class="nav-item" @click="logout">
          <a class="nav-link" href="#">Logout</a>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script>
import auth from '../auth';

export default {
  name: 'SnippetNavigation',
  methods: {
    logout() {
      auth.logout();
      this.$router.go('/');
    },
  },
};
</script>

<style>
nav {
  margin-bottom: 20px;
  background-color: #611aa6;
  padding-bottom: 0% !important;
  padding-top: 0% !important;
}
a.navbar-brand,
a.nav-link {
  font-family: 'Acme', sans-serif;
}

</style>
