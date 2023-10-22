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
            console.log('hello 1',newToken)
            if(newToken === null){
                state.isAuth = false;
            } else {
                state.isAuth = true;
            }
            state.token = newToken;
            localStorage.setItem('user-token',state.token)
        },
        changeUserInfo(state,userData){
            console.log('hello 2',userData)
            state.email = userData.email;
            state.name = userData.firstName;
            state.lastname = userData.lastName;
            state.middlename = userData.middleName;
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

            const res = await axios.get('/api/Auth/check');
            if(!res.data.valid){
                dispatch('logout');
            }
        },
        async getUserInfo({ dispatch, commit }){
            const res = await axios.get('/api/Auth/user');
            commit('changeUserInfo',res.data);
            // if(res.data.success){
            //
            // } else {
            //     dispatch('logout');
            // }
        },
        logout({ commit }){
            commit('changeToken',null);
        },
        async login({ dispatch, commit},credentials){
            const res = await axios.post('/api/Auth/login',credentials);
            if(res.data.success){
                commit('changeToken',res.data.token);
                dispatch('getUserInfo');
                return true;
            } else {
                return false
                // TO-DO: Handle bad response
            }
        },
        async register({ commit,dispatch }, credentials){
            const res = await axios.post('/api/Auth/register',credentials);
            await dispatch('login',{
                login:credentials.email,
                password:credentials.password
            })
            if(res.data.success){
                // commit('changeToken',res.data.token);
                // dispatch('getUserInfo');
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