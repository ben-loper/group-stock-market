<template>
    <div id="landing">
        <h1>Stockr</h1>
        <div class="row">
            <div class="column">
                <p id="description">
                    Stockr is the world's greatest stock purchasing/tracking application.
                    You can manage your portfolio, buy and sell stocks, follow favorites, and more!
                    Over three people worldwide are getting things done with Stockr. What will YOU do?
                </p>
            </div>
            <div class="column">
                <div id="marketNews">
                    Here is the space where market news type stuff will go!
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {

}
</script>

<style>

#description {
    border-style: solid;
    border-width: 2px;
}

#marketNews {
    border-style: solid;
    border-width: 2px;
}

.row {
  display: flex;
}

.column {
  flex: 50%;
}

</style>
