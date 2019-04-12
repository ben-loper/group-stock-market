<template>
    <nav class="navbar navbar-expand navbar-dark">
    <router-link to="/" class="navbar-brand">
      <img src="../assets/Stockr-logo-nav.png" alt width="140"/>
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
        <router-link tag="li" class="nav-item" to="/" active-class="active" exact>
          <a class="nav-link">Home</a>
        </router-link>
        <router-link tag="li" class="nav-item" to="/about" active-class="active">
          <a class="nav-link">About</a>
        </router-link>
      </ul>
    </div>
    <div class="navbar-collapse collapse">
      <ul class="navbar-nav ml-auto">
        <router-link tag="li" class="nav-item" to="/login" active-class="active" exact>
          <a class="nav-link">Login</a>
        </router-link>
      </ul>
    </div>
  </nav>
</template>

<script>
export default {

}
</script>

<style scoped>

nav {
  margin-bottom: 20px;
  background-color: #611aa6;
  padding-bottom: 0%;
  padding-top: 0%;
}
a.navbar-brand,
a.nav-link {
  font-family: 'Acme', sans-serif;
}
</style>
