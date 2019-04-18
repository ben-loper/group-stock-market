<template class="landing-template">
  <div id="landing">
    <default-layout></default-layout>

    <div>
      <h2 class="landing-h2" style="float: left; margin-left: 15%;">What IS Stockr?</h2>
      <h2 class="landing-h2" style="margin-left: 64%; margin-right: 21%;">Market News</h2>
    </div>
    <div id="leftColumn">
      <div id="description">
        Stockr is the world's greatest stock purchasing/tracking application.
        You can manage your portfolio, buy and sell stocks, follow favorites, and more!
        Over three people worldwide are getting things done with Stockr. What will YOU do?
      </div>
    </div>

    <div id="marketNews">
      <vue-rss-feed :feedUrl="feedUrl" :name="name" :limit="limit"/>
    </div>

    <h2
      class="landing-h2"
      style="margin-left: 17%; margin-right: 70%; position: relative; top: -365px;"
    >Hot Stocks</h2>

    <div id="marketStuff">
      <table class="table table-striped">
        <thead class="thead-dark">
          <tr>
            <th scope="col">Symbol</th>
            <th scope="col">Price</th>
          </tr>
        </thead>
        <tr v-for="stock in hotStocks" :key="stock.name">
          <td>{{ stock.name }}</td>
          <td>{{ stock.price }}</td>
        </tr>
      </table>
    </div>
  </div>
</template>

<script>
import DefaultLayout from "@/layouts/DefaultLayout";
import VueRssFeed from "vue-rss-feed";

export default {
  name: "Landing",
  components: {
    DefaultLayout,
    VueRssFeed
  },

  data() {
    return {
      hotStocks: [],
      feedUrl: `https://cors-anywhere.herokuapp.com/https://feeds.a.dj.com/rss/RSSMarketsMain.xml`,
      name: "",
      limit: 10
    };
  },

  created() {
    var topStocks = ["AAPL", "FB", "MSFT", "BA", "JPM"];

    topStocks.forEach(item => {
      fetch(
        `https://cloud.iexapis.com/beta/stock/${item}/quote/?token=pk_cdd72b15fa2a4735897c36067dd39008`
      )
        .then(resp => {
          return resp.json();
        })
        .then(resp => {
          this.hotStocks.push({ name: resp.symbol, price: resp.latestPrice });
          const test = this.hotStocks;
          this.$forceUpdate();
          return resp;
        });
    });
  }
};
</script>

<style>
html {
  background-color: #f5f5f5;
  /* background-image: url("../assets/wallstreet-bull.jpg");
    background-repeat: no-repeat;
    background-size: cover;
    background-position: 5%; */
}

#marketStuff {
  border-style: solid;
  border-width: 2px;
  border-radius: 5px;
  margin-left: 2%;
  float: left;
  width: 42%;
  margin-bottom: 10pt;
  position: relative;
  top: -372px;
  background-color: #f5f5f5;
}

#description {
  border-style: solid;
  border-width: 2px;
  border-radius: 5px;
  float: left;
  margin-left: 2%;
  width: 42%;
  padding: 10px;
  background-color: #f5f5f5;
}

#marketNews {
  border-style: solid;
  border-width: 2px;
  border-radius: 5px;
  margin-left: 46%;
  margin-right: 2%;
  padding: 10px;
  height: 352pt;
  overflow-y: scroll;
  background-color: #f5f5f5;
}

.landing-h2 {
  background-color: #f5f5f5;
  padding: 0.5%;
  /* border: 2px solid black; */
  border-radius: 5px;
  text-align: center;
}

.landing-h2 > div {
  background-color: #f5f5f5;
  padding: 0.5%;
  /* border: 2px solid black; */
  border-radius: 5px;
}
</style>
