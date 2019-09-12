<template>
  <div id="app">
    <link href="https://fonts.googleapis.com/css?family=Material+Icons" rel="stylesheet" />
    <full-page :options="options" id="fullpage">
      <div class="section fp-section">
        <div class="slide">
          <v-container grid-list-md text-xs-center>
            <v-layout row wrap>
              <v-flex xs6>
                <v-card color="secondary" flat>
                  <img src="https://img.icons8.com/bubbles/100/000000/restaurant.png" height="150" />
                </v-card>
              </v-flex>
              <v-flex xs6>
                <v-card color="secondary" flat>
                  <a href="#page2">
                    <h1 class="display-1 ma-2 text-xs-left" style="color:black">To restaurant</h1>
                  </a>
                  <a href="#page1/1">
                    <h1 class="display-1 ma-2 text-xs-left" style="color:black">To my reservation</h1>
                  </a>
                </v-card>
              </v-flex>
            </v-layout>
          </v-container>
        </div>
        <div class="slide">
          <v-container grid-list-md text-xs-center>
            <v-layout row wrap>
              <h1
                class="display-1 ma-2 text-xs-left"
                style="color:black"
              >Please insert your reservation code:</h1>

              <v-flex xs12 sm6 md4>
                <v-text-field label="Code" placeholder="your code.." box></v-text-field>
              </v-flex>

              <v-btn outline fab :disabled="true" color="indigo">
                <v-icon dark>chevron_right</v-icon>
              </v-btn>
            </v-layout>
          </v-container>
        </div>
        <div class="slide">
          <Appointments />
        </div>
      </div>
      <div class="section">
        <Home @loadAppointments="onLoadAppointments" />
      </div>
      <div class="section">
        <Agenda @clicked="onClickChild" :events="events" :tableId="pickedTableId" />
      </div>
      <div class="section">
        <div v-if="isPayVisible">
          <h1>You have to pay {{amountToPay}} RON.</h1>
          <v-container grid-list-md text-xs-center>
            <v-layout row wrap>
              <v-flex xs6>
                <h2 class="display-1 ma-2 text-xs-center">Card number:</h2>
                <br />
                <h2 class="display-1 ma-2 text-xs-center" style="padding-top:15px">Month | Year</h2>
                <br />
                <h2 class="display-1 ma-2 text-xs-center" style="padding-top:15px">CVS</h2>
                <br />
                <h2 class="display-1 ma-2 text-xs-center" style="padding-top:15px">CardHolder name</h2>
                <br />
              </v-flex>
              <v-flex xs6>
                <v-text-field return-masked-value mask="#### #### #### ####"></v-text-field>
                <br />
                <div style="display:flex">
                  <v-text-field return-masked-value mask="##"></v-text-field>||
                  <v-text-field return-masked-value mask="##"></v-text-field>
                </div>
                <br />
                <v-text-field return-masked-value mask="###"></v-text-field>
                <br />
                <v-text-field return-masked-value></v-text-field>
              </v-flex>
            </v-layout>
            <v-layout row wrap>
              <v-flex xs6>
                <v-btn
                  @click="moveToAgendaPage"
                  style="background-color: orange"
                  x-large
                  color="warning"
                  dark
                >Deny Payment</v-btn>
              </v-flex>
              <v-flex xs6>
                <v-btn
                  @click="saveAppointment"
                  style="background-color: #4CAF50;"
                  x-large
                  color="success"
                  dark
                >Accept Payment</v-btn>
              </v-flex>
            </v-layout>
          </v-container>
        </div>
        <div v-else>
          <h1>Issue occured: {{amountToPay}}</h1>
          <v-container grid-list-md text-xs-center>
            <v-layout row wrap>
              <v-flex xs6>
                <v-btn
                  @click="moveToAgendaPage"
                  style="background-color: #4CAF50;"
                  x-large
                  color="success"
                  dark
                >Back</v-btn>
              </v-flex>
            </v-layout>
          </v-container>
        </div>
      </div>
      <div class="section fp-section">
        <div class="slide">
          <h1>
            Congratulations!
            <br />
          </h1>
          <h1 style="font-size: 15px;">
            Your reservation has been successfuly created!
            <br />You can also pre-order your menu by pressing the following button
            <br />This will be activated when arriving at the restaurant
          </h1>
          <h1>
            <v-btn @click="moveToMenuPage" style="background-color: #4CAF50;" fab large dark />
          </h1>
        </div>
        <div class="slide">
          <v-container grid-list-md text-xs-center>
            <v-layout row wrap>
              <v-flex xs6>
                <v-tabs v-model="tab" background-color="transparent" grow>
                  <v-tab
                    v-for="item in items"
                    :key="item.category"
                    @click="tabWasChanged(item.category)"
                  >{{ item.header }}</v-tab>
                </v-tabs>

                <v-tabs-items v-model="tab">
                  <v-tab-item v-for="item in items" :key="item.category">
                    <v-data-table
                      :items="filteredItems"
                      class="elevation-1"
                      hide-actions
                      hide-headers
                    >
                      <template v-slot:items="props">
                        <td class="text-left">{{ props.item.name }}</td>
                        <td class="text-xs-right">{{ props.item.price }}</td>
                        <td>
                          <v-btn fab dark small color="green" @click="AddItemToReceip(props.item.id)">
                            <v-icon dark>add</v-icon>
                          </v-btn>
                        </td>
                      </template>
                    </v-data-table>
                  </v-tab-item>
                </v-tabs-items>
              </v-flex>
              <v-flex xs6>
                <v-card color="secondary" flat>
                  <a href="#page2">
                    <h1 class="display-1 ma-2 text-xs-left" style="color:black">To restaurant</h1>
                  </a>
                  <a href="#page1/1">
                    <h1 class="display-1 ma-2 text-xs-left" style="color:black">To my reservation</h1>
                  </a>
                </v-card>
              </v-flex>
            </v-layout>
          </v-container>
        </div>
      </div>
    </full-page>
  </div>
</template>

<script>
require("@/utils/style.css");
import Home from "./Home";
import Agenda from "./Agenda";
import Appointments from "./Appointments";

export default {
  components: {
    Home,
    Agenda,
    Appointments
  },
  name: "MainPage",
  data() {
    return {
      amountToPay: "",
      isPayVisible: true,
      img: require("@/assets/IMG_8262.jpg"),
      options: {
        afterLoad: this.afterLoad,
        scrollOverflow: true,
        scrollBar: false,
        menu: "#menu",
        navigation: true,
        controlArrows: true,
        anchors: ["page1", "page2", "page3", "page4", "page5"],
        sectionsColor: []
      },
      events: [],
      pickedTableId: 0,
      tab: null,
      items: [
        { header: "Appetizers", category: 1, sortable: false },
        { header: "Entrees", category: 2, sortable: false },
        { header: "Deserts", category: 3, sortable: false },
        { header: "Drinks", category: 4, sortable: false }
      ],
      menuItems: [
        { id: 1, name: "Frozen Yogurt", category: 1, price: 10 },
        { id: 2, name: "Frozen Yogurt2", category: 2, price: 10 },
        { id: 3, name: "Frozen Yogurt3", category: 3, price: 10 },
        { id: 4, name: "Frozen Yogurt4", category: 4, price: 10 },
        { id: 5, name: "Frozen Yogurt5", category: 1, price: 10 },
        { id: 6, name: "Frozen Yogurt6", category: 1, price: 10 },
        { id: 7, name: "Frozen Yogurt7", category: 2, price: 10 },
        { id: 8, name: "Frozen Yogurt8", category: 3, price: 10 }
      ],

      filteredItems: []
    };
  },
  created: function() {
    var int1 = setInterval(function() {
      var currentHour = new Date().getHours();

      if (currentHour == 10) {
        clearInterval(int1);
      }
    }, 900000); //check time on 15min
  },
  methods: {
    AddItemToReceip(itemId){
      console.log(itemId);
    },
    tabWasChanged(category) {
      this.filteredItems = [];
      this.menuItems.forEach(menuItem => {
        if (menuItem.category == category) {
          this.filteredItems.push(menuItem);
        }
      });
    },
    saveAppointment() {
      var event = this.$session.get("appointment");
      this.axios
        .get("https://localhost:44379/Appointments/SaveAppointment", {
          headers: {
            "Access-Control-Allow-Origin": "*"
          },
          params: {
            restaurantId: 1,
            tableId: this.pickedTableId,
            agendaEvent: JSON.stringify(event)
          }
        })
        .then(response => {
          location.hash = "#page5";
        })
        .catch(function() {});
    },
    moveToAgendaPage() {
      this.axios
        .get("https://localhost:44379/Appointments/GetAppointments", {
          headers: {
            "Access-Control-Allow-Origin": "*"
          },
          params: {
            restaurantId: 1,
            tableId: this.pickedTableId
          }
        })
        .then(response => {
          response.data.forEach(a => (a.date = new Date(a.date)));
          this.events = response.data;
          location.hash = "#page3";
        })
        .catch(function() {});
    },
    moveToMenuPage() {
      location.hash = "#page5/1";
    },
    onClickChild(isPay, value) {
      this.amountToPay = value;
      this.isPayVisible = isPay;
      location.hash = "#page4";
    },
    addSection: function() {
      var newSectionNumber =
        document.querySelectorAll(".fp-section").length + 1;

      // creating the section div
      var section = document.createElement("div");
      section.className = "section";
      section.innerHTML = `<h3>Section ${newSectionNumber}</h3>`;

      // adding section
      document.querySelector("#fullpage").appendChild(section);

      // creating the section menu element
      var sectionMenuItem = document.createElement("li");
      sectionMenuItem.setAttribute(
        "data-menuanchor",
        "page" + newSectionNumber
      );
      sectionMenuItem.innerHTML = `<a href="#page${newSectionNumber}">Section${newSectionNumber}</a>`;

      // adding anchor for the section
      this.options.anchors.push(`page${newSectionNumber}`);

      // we have to call `update` manually as DOM changes won't fire updates
      // requires the use of the attribute ref="fullpage" on the
      // component element, in this case, <full-page>
      // ideally, use an ID element for that element too
      this.$refs.fullpage.build();
    },

    removeSection: function() {
      var sections = document
        .querySelector("#fullpage")
        .querySelectorAll(".fp-section");
      var lastSection = sections[sections.length - 1];

      // removing the last section
      lastSection.parentNode.removeChild(lastSection);

      // removing the last anchor
      this.options.anchors.pop();

      // removing the last item on the sections menu
      var sectionsMenuItems = document.querySelectorAll("#menu li");
      var lastItem = sectionsMenuItems[sectionsMenuItems.length - 1];
      lastItem.parentNode.removeChild(lastItem);
    },
    onLoadAppointments: function(appointments, targetTableId) {
      appointments.forEach(a => (a.date = new Date(a.date)));
      this.events = appointments;
      this.pickedTableId = targetTableId;
    }
  }
};
</script>

