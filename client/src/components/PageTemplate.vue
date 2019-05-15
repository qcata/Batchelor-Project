<template>
<v-content>
  <div>
    <v-layout white--text align-center column justify-center style="margin-top: 8.5em;">
          <img src="https://townshipcanada.com/static/logo.svg" height="150"/>
          <h3 class=" display-3 ma-2 text-xs-center">Restaurant</h3>
        </v-layout>
  </div>
  <div style="position: relative;">
      <parallax :fixed="true" :sectionHeight="10">
        <img :src="img" alt="very cool bg">
      </parallax>
  </div>
  <div style="background-color: #fff; height: 100vh;"></div>
      <div>
        
      </div>
</v-content>
</template>


<script>

import Parallax from 'vue-parallaxy'

export default {
        components: {
          Parallax
        },
        name : 'PageTemplate',
        data(){
          return{
            img: require('@/assets/IMG_8262.jpg')
          }
        }
    }

</script>
