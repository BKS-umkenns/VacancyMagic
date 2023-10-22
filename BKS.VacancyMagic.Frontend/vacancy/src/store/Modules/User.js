import axios from "axios";

export default {
    namespaced: true,
    state: () => ({
        email:'',
        name:'',
        lastname:'',
        middlename:'',
        token:null,
        isAuth:false,
    }),
    mutations: {
        changeToken(state,newToken){
            if(newToken === null){
                state.isAuth = false;
            }
            state.token = newToken;
            localStorage.setItem('user-token',state.token)
        },
        changeUserInfo(state,userData){
            state.email = userData.email;
            state.name = userData.name;
            state.lastname = userData.lastname;
            state.middlename = userData.middlename;
        }
    },
    actions: {
        async checkIfTokenStillValid({ getters, dispatch, commit }){
            const savedToken = localStorage.getItem('user-token');
            if(!savedToken){
                commit('changeToken', null);
                return console.error('Token is not valid')
            }
            getters.token = savedToken;

            const res = await axios.get('/api/check');
            if(!res.data.valid){
                dispatch('logout');
            }
        },
        async getUserInfo({ dispatch, commit }){
            const res = await axios.get('/api/user');
            if(res.data.success){
                commit('changeUserInfo',res.data);
            } else {
                dispatch('logout');
            }
        },
        logout({ commit }){
            commit('changeToken',null);
        },
        async login({ dispatch, commit},credentials){
            const res = await axios.post('/api/Auth/login',credentials);
            if(res.data.success){
                commit('changeToken',res.data.token);
                dispatch('getUserInfo');
            } else {
                // TO-DO: Handle bad response
            }
        },
        async register({ commit,dispatch }, credentials){
            const res = await axios.post('/api/Auth/register',credentials);
            if(res.data.success){
                commit('changeToken',res.data.token);
                dispatch('getUserInfo');
            } else {
                // TO-DO: Handle bad response
            }
        }
    },
    getters: {
        getToken(state){
            return state.token;
        },
        user(state){
            return {
                name: state.name,
                lastname: state.lastname
            }
        },
        isAuth(state){
            return state.isAuth
        }
    }
}