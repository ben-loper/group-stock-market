import Vue from 'vue';
import Router from 'vue-router';
import ListSnippets from '@/views/ListSnippets';
import ListPortfolio from '@/views/ListPortfolio';
import Landing from '@/views/Landing';
import ViewSnippet from '@/views/ViewSnippet';
import SaveSnippet from '@/views/SaveSnippet';
import Login from '@/views/Login';
import Register from '@/views/Register';
import About from '@/views/About';
import auth from './auth';
import Trades from '@/views/Trades';

Vue.use(Router);

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'landing',
      component: Landing,
    },
    {
      path: '/snippetsList',
      name: 'snippetList',
      component: ListSnippets,
    },
    { path: '/portfolio',
      name: 'listPortfolio',
      component: ListPortfolio,
    },
    {
      path: '/snippet/:id',
      name: 'snippet',
      component: ViewSnippet,
      props: true,
    },
    {
      path: '/save/:id?',
      name: 'save',
      component: SaveSnippet,
    },
    {
      path: '/login',
      name: 'login',
      component: Login,
    },
    {
      path: '/register',
      name: 'register',
      component: Register,
    },
    {
      path: '/about',
      name: 'about',
      component: About,
    },
    {
      path: '/trades',
      name: 'trades',
      component: Trades,
    }
  ],
});

router.beforeEach((to, from, next) => {
  // redirect to login page if not logged in and trying to access a restricted page
  const publicPages = ['/login', '/register', '/', '/about'];
  const authRequired = !publicPages.includes(to.path);
  const loggedIn = auth.getUser();

  if (authRequired && !loggedIn) {
    return next('/');
  }

  next();
});

export default router;
