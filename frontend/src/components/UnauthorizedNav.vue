<template>
    <nav class="navbar navbar-expand navbar-dark">
    <router-link to="/landing" class="navbar-brand">
    <figure>
      <img src="../assets/Stockrlogo.png" alt width="140" id="stockrLogo"/>
    </figure>
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
        <router-link tag="li" class="nav-item" to="/landing" active-class="active" exact>
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

figure{
   width:130px; /*container-width*/
   overflow:hidden; /*hide bounds of image */
   margin:0;   /*reset margin of figure tag*/
}

#stockrLogo{
  
  margin:-21.875% 0;
}
nav {
  margin-bottom: 20px;
  background-color: #611aa6;
}
a.navbar-brand,
a.nav-link {
  font-family: 'Acme', sans-serif;
}
</style>
