const component = Vue.component('checkbox-component', {
    props: {
        isChecked: Boolean,
        id: Number,
        callBack: {
            type: Function
        }
    },
    template: `
    <div>
      <input type="checkbox" v-model="isChecked" @change="handleCallback">
    </div>
  `,
    methods: {
        handleCallback() {
            this.callBack(this.id, this.isChecked);
        }
    }
});

export default component;