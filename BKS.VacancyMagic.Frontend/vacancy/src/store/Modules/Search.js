export default {
    namespaced:'Search',
    state: ()=>({
        actualPromt:'',
        actualStep:2,
        vacancies: [
            {
                id:1,
                serviceId:'hh',
                serviceLogoUrl:'/hhLogo.png',
                inServiceId:3432,
                employer:'Яндекс',
                title:'Дериктор по логистике курьеров',
                description: 'Подробное описание ахахаххывахы авыа ыавыва выа ыва ывафавыфпвыаыввф аывфсыв',
                tags: [
                    {
                        id:1,
                        name:'Зарплата',
                        value:'1000 р'
                    }
                ]
            }
        ]
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
            state.vacancies = [];
        }
    },
    getters:{
        isValidPromtText(state){
            return state.actualPromt.length < 125;
        },
        vacancies(state){
            return state.vacancies
        },
        searchState(state){
            return state;
        }
    }
}