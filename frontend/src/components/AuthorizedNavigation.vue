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
        <router-link tag="li" class="nav-item" to="/about" active-class="active">
          <a class="nav-link">About</a>
        </router-link>
        <router-link tag="li" class="nav-item" to="/portfolio" active-class="active" exact>
          <a class="nav-link">Portfolio</a>
        </router-link>
        <router-link tag="li" class="nav-item" to="/stockdetail" active-class="active" exact>
          <a class="nav-link">Research</a>
        </router-link>  
        <!-- <router-link tag="li" class="nav-item" to="/trades" active-class="active" exact>
          <a class="nav-link">Buy/Sell</a>
        </router-link> -->
          <router-link tag="li" class="nav-item" to="/history" active-class="active" exact>
          <a class="nav-link">History</a>
        </router-link>
      </ul>
    </div>
    <div class="navbar-collapse collapse">
      <ul class="navbar-nav ml-auto">
        <li class="nav-item" id="greeting">Hello {{user.fName}}  | </li>
        <li class="nav-item" @click="logout">
          <a class="nav-link" href="#">Logout</a>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script>
import auth from '../auth';
import EventBus from '../event-bus';
import {globals} from '@/main.js';

export default {
  name: 'authorized-navigation',
  methods: {
    logout() {
      auth.logout();
      this.$router.go('/');
    },
    searchCompany(){
      globals.search = document.getElementById('search').value;
      this.$router.push({ name: 'stockDetail'});
      
      // EventBus.$emit('search-company', query);
      this.$emit('search-company');
      //this.$router.go('/stockdetail');
    }
    // filterTasks() {
    // const query = document.getElementById('search').value;
    // this.$emit('filter-tasks', query);

    //     }
  },
    data() {
    return{ user:null
    }
  },
  beforeMount() {
    this.user = auth.getUser();
  }
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

.navbar-dark .navbar-nav .show > .nav-link, .navbar-dark .navbar-nav .active > .nav-link, .navbar-dark .navbar-nav .nav-link.show, .navbar-dark .navbar-nav .nav-link.active {
    color: #bffbfb !important;
}

.form-inline {
  text-align: center;
}

#greeting {
  color: rgba(255, 255, 255, 0.5);
  padding-top: 5.5%;
}
</style>
