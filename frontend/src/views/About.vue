<template>
    <div>
        <h2 style="margin-left: 5%; margin-top: 3%;">Our Story</h2>
        <div class="story-text">
        <h5>Coming from previous careers in pharmaceutical/tech sales, mutual fund accounting, QA software testing, and retail sales management, we enrolled at 
            Tech Elevator with the hopes of forging new paths as software developers. Over the past 14 weeks, we've learned a tremendous amount of technical skills and 
            fostered new relationships with each other that are sure to last a lifetime. Upon graduation from the program, we'll all venture off into our new careers 
            as junior developers at various companies in the Greater Cincinnati area. We designed STOCKR to be a culmination of our full education here at Tech Elevator, 
            and hope that you share in our excitement of its creation by making use of it to help manage your stock portfolios in the future. </h5>
        </div>
        <div class="image-container"> 
            <div class="our-image">
            <img src="../assets/Adam-stockr.jpg" />
            </div>
            <div class="our-image">
            <img src="../assets/John-stockr.jpg" />
            </div>
            <div class="our-image">
            <img src="../assets/Adam-stockr.jpg" />
            </div>
            <div class="our-image">
            <img src="../assets/Josh-stockr.jpg" />
            </div>
        </div>
    </div>
</template>

<script>
export default {

}
</script>

<style>
.story-text {
    display: flex;
    width: 90%;
    margin-left: 5%;
    margin-right: 5%;
}

.image-container {
    display: flex;
    margin-left: 5%;
    margin-top: 3%;
    margin-right: 5%;
}

.our-image>img {
    width: 75%;
    border-radius: 5%;
}

.our-image {
    width: 25%;
}
</style>
