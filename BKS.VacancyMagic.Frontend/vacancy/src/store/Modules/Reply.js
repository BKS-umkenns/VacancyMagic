export default {
    namespaced:'Reply',
    state:()=>({
        list: [
            {
                id:1,
                createdAt:'2023',
                serviceId:'hh',
                employer:'Яндекс',
                vacancyName:'Главный тута',
                description:'Ответсвенная должность...',
                status: 1
            },
            {
                id:2,
                createdAt:'2022',
                serviceId:'sj',
                employer:'ИП Иванов',
                vacancyName:'Уборщик',
                description:'!!! ТОЛЬКО ДЛЯ ОТВЕТСВЕННЫХ !!!',
                status:2
            }
        ],
        statuses: [
            {
                id:1,
                color:'warning',
                title:'Отправлено'
            },
            {
                id:2,
                color:'success',
                title:'Собеседование'
            }
        ],
        companies: [
            {
                id: 'hh',
                logo:'/hhLogo.png'
            },
            {
                id: 'sj',
                logo:'/superjob_logo_180.png'
            }
        ],
    }),
    actions:{

    },
    getters: {
        items(state){
            return state.list
        },
        statuses(state){
            return state.statuses;
        },
        services(state){
            return state.companies;
        }
    }
}