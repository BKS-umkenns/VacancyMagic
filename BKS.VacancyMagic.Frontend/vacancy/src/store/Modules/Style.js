export default {
    namespaced: 'Style',
    state: ()=>({
        isMobile:false,
    }),
    mutations: {
        changeIsMobile(state,newValue){
            state.isMobile = newValue;
        }
    },
    getters: {
        isMobile(state){
            return state.isMobile
        }
    }
}