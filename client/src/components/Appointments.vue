<template>
    <v-container grid-list-md text-xs-center>   
        <v-data-table
        v-model="selected"
        :headers="headers"
        :items="items"
        hide-actions
        select-all
        >
        <template
            slot="headerCell"
            slot-scope="{ header }"
        >
            <span
            class="subheading font-weight-light text-success text--darken-3"
            v-text="header.text"
            />
        </template>
        <template
            slot="items"
            slot-scope="{ item }"
        >
        
        <td>
          <v-checkbox
            primary
            hide-details
            :input-value="item.selected"
          ></v-checkbox>
        </td>

            <td>{{ item.table }}</td>
            <td>{{ item.start_time }}</td>
            <td>{{ item.end_time }}</td>
            <td class="text-xs-right">
                <div v-if="item.status_id == true">
                    <v-icon large color="green darken-2">check_circle</v-icon>
                </div>
                <div v-else>
                    <v-icon large color="red darken-2">cancel</v-icon>
                </div>
            </td>
        </template>
        </v-data-table>
    </v-container>
</template>

<script>
export default{
  name: "Appointments",
  data: () => ({
    selected: [],
    headers: [
      {
        sortable: false,
        text: 'Table',
        value: 'table',
        align: 'center'
      },
      {
        sortable: false,
        text: 'Start Time',
        value: 'start_time',
        align: 'center'
      },
      {
        sortable: false,
        text: 'End Time',
        value: 'end_time',
        align: 'center'
      },
      {
        sortable: false,
        text: 'Status',
        value: 'status',
        align: 'right'
      }
    ],
    items: [
      {
        table: '1',
        start_time: '12:00',
        end_time: '13:00',
        status_id: true
      },
      {
        table: '6',
        start_time: '18:00',
        end_time: '20:00',
        status_id: false
      }, {
        table: '4',
        start_time: '18:00',
        end_time: '20:00',
        status_id: true
      }, {
        table: '4',
        start_time: '12:00',
        end_time: '13:00',
        status_id: true
      }, {
        table: '6',
        start_time: '14:00',
        end_time: '16:00',
        status_id: true
      }
    ],
  }),
  methods: {
      toggleAll () {
        if (this.selected.length) this.selected = []
        else this.selected = this.items.slice()
      }
    }
}
</script>