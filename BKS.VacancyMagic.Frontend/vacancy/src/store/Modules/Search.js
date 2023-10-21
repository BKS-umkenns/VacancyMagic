export default {
    namespaced:'Search',
    state: ()=>({
        actualPromt:'',
        actualStep:0,
    }),
    actions:{
        newStart({commit}){
            commit('clear')
        }
    },
    mutations: {
        changeState(state,newStateData){
            if(newStateData?.actualPromt) state.actualPromt = newStateData.actualPromt;
            if(newStateData?.actualStep) state.actualStep = newStateData.actualStep;
        },
        clear(state){
            state.actualPromt = '';
            state.actualStep = 0;
        }
    },
    getters:{
        isValidPromtText(state){
            return state.actualPromt.length < 125;
        },
        searchState(state){
            return state;
        }
    }
}