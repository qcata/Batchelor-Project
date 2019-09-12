<template>
  <v-layout>
    <v-flex>
      <vue-scheduler
        :event-dialog-config="dialogConfig"
        @event-created="eventCreated"
        @week-changed="weekChanged"
        :events="events"
      />
    </v-flex>
  </v-layout>
</template>


<script>

export default {
  name: "Agenda",
  props: ["events", "tableId"],
  components: {
  },
  data() {
    return {
      dialogConfig: {
        title: "Create a reservation",
        createButtonLabel: "Go to payment",
        enableTimeInputs: true,

        fields: [
          {
            name: "Name",
            required: true,
            label: "Name"
          },
          {
            name: "PplCount",
            required: true,
            label: "How Many People?"
          },
          {
            name: "Email",
            type: "email",
            required: false,
            label: "E-mail"
          },
          {
            name: "Phone",
            required: true,
            label: "Phone number"
          },
          {
            name: "Comments",
            type: "textarea",
            label: "comments"
          }
        ]
      }
    };
  },
  methods: {
    eventCreated(event) {
      if (event != null) {
        if (!this.$session.exists()) {
              this.$session.start();
              this.$session.set('appointment', event);
        }
        else{
          this.$session.set('appointment', event);
        }
        this.axios
          .get(
            "https://localhost:44379/Appointments/ValidateAndComputeAppointmentSum",
            {
              headers: {
                "Access-Control-Allow-Origin": "*"
              },
              params: {
                restaurantId: 1,
                tableId: this.tableId,
                agendaEvent: JSON.stringify(event)
              }
            }
          )
          .then(response => {
            this.$emit('clicked',response.data.success, response.data.responseText);
          })
          .catch(function() {});
      }
    },
    weekChanged(newDate) {
      if (this.tableId != 0) {
        this.axios
          .get("https://localhost:44379/Appointments/GetAppointmentsForWeek", {
            headers: {
              "Access-Control-Allow-Origin": "*"
            },
            params: {
              restaurantId: 1,
              tableId: this.tableId,
              newWeek: newDate
            }
          })
          .then(response => {
            var formattedArray = response.data;
            formattedArray.forEach(a => (a.date = new Date(a.date)));
            this.events = formattedArray;
          })
          .catch(function() {});
      }
    }
  }
};
</script>