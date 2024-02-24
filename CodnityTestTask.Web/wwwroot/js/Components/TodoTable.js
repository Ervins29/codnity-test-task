import checkbox from "./checkbox.js";

const component = Vue.component('todo-table-component', {
    components: {
        "checkbox-component": checkbox
    },
    data: function () {
        return {
            todos: {},
            formData: {
                text: '',
                errors: null
            }
        };
    },
    template: `
    <div>
        <table class="table table-striped">
            <thead>
                <tr>
                    <th scope="col">Text</th>
                    <th scope="col">Is completed</th>
                    <th scope="col">Actions</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="todo in todos.todosList"">
                    <td>{{todo.text}}</td>
                    <td>
                        <checkbox-component :isChecked="todo.isCompleted" :callBack="toggleTodo" :id="todo.id"></checkbox-component>
                    </td>
                    <td>
                        <div class="d-inline-flex">
                            <div class="m-2">
                                <button type="submit" @click="deleteTodo(todo.id)" class="btn btn-danger">Delete</button>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="form-group">
                        <ul v-if="formData.errors">
                            <span v-for="(messages, field) in formData.errors" :key="field">
                                <li class="text-danger" v-for="message in messages" :key="message">{{ message }}</li>
                            </span>
                        </ul>
                        <input type="text" id="text" v-model="formData.text" class="form-control">
                    </td>
                    <td></td>
                    <td>
                        <button type="submit" class="btn btn-primary" @click="addTodo">Add</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
  `,
    mounted() {
        this.fetchTodos();
    },
    methods: {
        fetchTodos() {
            fetch("/api/getTodos")
                .then(response => {
                    if (!response.ok) {
                        throw new Error("Network error");
                    }
                    return response.json();
                })
                .then(data => {
                    this.todos = data;
                });
        },
        toggleTodo(id, value) {
            fetch("/api/toggleTodo", {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    Id: id,
                    value: value
                })
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error("Network error");
                    }
                })
                .then(() => {
                    this.fetchTodos();
                });
        },
        deleteTodo(id) {
            fetch("/api/deleteTodo", {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    Id: id,
                })
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error("Network error");
                    }
                })
                .then(() => {
                    this.fetchTodos();
                });
        },
        addTodo() {
            fetch("/api/addTodo", {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    Text: this.formData.text,
                })
            })
                .then(response => {
                    if (!response.ok) {
                        return response.json();
                    }
                    this.formData.text = '';
                })
                .then((data) => {
                    this.formData.errors = data;
                    this.fetchTodos();
                });
        }
    }
});

export default component;