import axios from "axios";

export default {
    namespaced:'Search',
    state: ()=>({
        actualPrompt:'',
        actualStep:2,
        vacancies: [
            {
                id:1,
                serviceId:'hh',
                serviceLogoUrl:'/hhLogo.png',
                inServiceId:3432,
                employer:'Яндекс',
                title:'Директор по логистике курьеров',
                description: '<p><b>Обязанности:</b></p><p><ul><li>проводит лучевые исследования в соответствии со стандартом медицинской помощи;</li><li>оформляет протоколы проведенных лучевых исследований по модальностям компьютерная томография(CT) и магнитно-резонансная томография(MR) с заключением о предполагаемом рентгенологическом диагнозе, необходимом комплексе уточняющих лучевых и других инструментальных исследований;</li><li>обеспечивает правильное и своевременное оформление медицинской и иной документации в соответствии с установленными правилами;</li><li>консультирует врачей других специальностей по вопросам обоснованного и рационального выбора лучевых исследований, оценивает динамику по результатам проведенных лучевых исследований с оформлением протокола, участвует в консилиумах, клинических разборах, клинико-диагностических конференциях.</li></ul><b>Требования:</b></p><p><ul><li>высшее образование - специалитет по одной из специальностей: \\"Лечебное дело\\", \\"Педиатрия\\" и подготовка в интернатуре и (или) ординатуре по специальности \\"Рентгенология\\", либо профессиональная переподготовка по специальности \\"Рентгенология\\" при наличии подготовки в интернатуре и (или) ординатуре по одной из специальностей: \\"Акушерство и гинекология\\", \\"Анестезиология-реаниматология\\", \\"Детская хирургия\\", \\"Детская онкология\\", \\"Детская эндокринология\\", \\"Гастроэнтерология\\", \\"Гематология\\", \\"Инфекционные болезни\\", \\"Кардиология\\", \\"Колопроктология\\", \\"Лечебная физкультура и спортивная медицина\\", \\"Нефрология\\", \\"Неврология\\", \\"Нейрохирургия\\", \\"Общая врачебная практика (семейная медицина)\\", \\"Онкология\\", \\"Оториноларингология\\", \\"Офтальмология\\", \\"Педиатрия\\", \\"Пульмонология\\", \\"Радиология\\", \\"Ревматология\\", \\"Рентгенэндоваскулярные диагностика и лечение\\", \\"Сердечно-сосудистая хирургия\\", \\"Скорая медицинская помощь\\", \\"Торакальная хирургия\\", \\"Терапия\\", \\"Травматология и ортопедия\\", \\"Ультразвуковая диагностика\\", \\"Урология\\", \\"Фтизиатрия\\", \\"Хирургия\\", \\"Эндокринология\\";</li><li>сертификат специалиста или свидетельство об аккредитации специалиста по специальности «Рентгенология»;</li><li>наличие сертификатов по повышению квалификации КТ и МРТ в онкологии;</li><li>наличие действующего удостоверения по радиационной безопасности;</li><li>знание КТ И МРТ в онкологии с опытом работы более 5 лет;</li><li>умение работать в ЕМИАСе и ЕРИСе, уверенный пользователь ПК;</li><li>умение консультировать специалистов клинических дисциплин и пациентов, оперативность в работе, командная работа в коллективе, стрессоустойчивость, знание английского языка приветствуется.</li></ul><b>Условия:</b></p><p><ul><li>трудоустройство в соответствии с ТК РФ;</li><li>график работы: дневной, сменный, 30-ая рабочая неделя на 1,0 ставку;</li><li>заработная плата по результатам собеседования.</li><li>Для членов Профсоюза реализованы следующие проекты:</li><li>Медицинское сопровождение;</li><li>Созданы спортивные команды из числа членов ППО и работников ММКЦ «Коммунарка», принимающие участия в официальных соревнованиях от Департамента здравоохранения Москвы и Московской Федерации Профсоюзов;</li><li>Бесплатные занятия по Йоге;</li><li>Скидочная программа в столовой на территории ММКЦ «Коммунарка»;</li><li>Поездки на тематические экскурсии, курорты, Здравницы;</li><li>Льготная программа в детских оздоровительных лагерях;</li><li>Скидки и бесплатные билеты в театры, на мюзиклы, спектакли, при условии наличия специального предложения от организаторов;</li><li>Помощь при поступлении ребёнка в первый класс;</li><li>Помощь при принятии ребёнка в детский сад;</li><li>Участие в благотворительных мероприятиях.</li></ul>Ключевые навыки </p>',
                tags: [
                    {
                        id:1,
                        name:'Зарплата',
                        value:'10000 руб',
                        color:'danger',
                    },
                    {
                        id:2,
                        name:'Логистика',
                        value:'',
                        color:'',
                    },
                    {
                        id:3,
                        name:'Директор',
                        value:'',
                        color:'success',
                    }
                ]
            },
            {
                id:2,
                serviceId:'hh',
                serviceLogoUrl:'/hhLogo.png',
                inServiceId:3432,
                employer:'Яндекс',
                title:'Директор по логистике курьеров',
                description: '<p><b>Обязанности:</b></p><p><ul><li>проводит лучевые исследования в соответствии со стандартом медицинской помощи;</li><li>оформляет протоколы проведенных лучевых исследований по модальностям компьютерная томография(CT) и магнитно-резонансная томография(MR) с заключением о предполагаемом рентгенологическом диагнозе, необходимом комплексе уточняющих лучевых и других инструментальных исследований;</li><li>обеспечивает правильное и своевременное оформление медицинской и иной документации в соответствии с установленными правилами;</li><li>консультирует врачей других специальностей по вопросам обоснованного и рационального выбора лучевых исследований, оценивает динамику по результатам проведенных лучевых исследований с оформлением протокола, участвует в консилиумах, клинических разборах, клинико-диагностических конференциях.</li></ul><b>Требования:</b></p><p><ul><li>высшее образование - специалитет по одной из специальностей: \\"Лечебное дело\\", \\"Педиатрия\\" и подготовка в интернатуре и (или) ординатуре по специальности \\"Рентгенология\\", либо профессиональная переподготовка по специальности \\"Рентгенология\\" при наличии подготовки в интернатуре и (или) ординатуре по одной из специальностей: \\"Акушерство и гинекология\\", \\"Анестезиология-реаниматология\\", \\"Детская хирургия\\", \\"Детская онкология\\", \\"Детская эндокринология\\", \\"Гастроэнтерология\\", \\"Гематология\\", \\"Инфекционные болезни\\", \\"Кардиология\\", \\"Колопроктология\\", \\"Лечебная физкультура и спортивная медицина\\", \\"Нефрология\\", \\"Неврология\\", \\"Нейрохирургия\\", \\"Общая врачебная практика (семейная медицина)\\", \\"Онкология\\", \\"Оториноларингология\\", \\"Офтальмология\\", \\"Педиатрия\\", \\"Пульмонология\\", \\"Радиология\\", \\"Ревматология\\", \\"Рентгенэндоваскулярные диагностика и лечение\\", \\"Сердечно-сосудистая хирургия\\", \\"Скорая медицинская помощь\\", \\"Торакальная хирургия\\", \\"Терапия\\", \\"Травматология и ортопедия\\", \\"Ультразвуковая диагностика\\", \\"Урология\\", \\"Фтизиатрия\\", \\"Хирургия\\", \\"Эндокринология\\";</li><li>сертификат специалиста или свидетельство об аккредитации специалиста по специальности «Рентгенология»;</li><li>наличие сертификатов по повышению квалификации КТ и МРТ в онкологии;</li><li>наличие действующего удостоверения по радиационной безопасности;</li><li>знание КТ И МРТ в онкологии с опытом работы более 5 лет;</li><li>умение работать в ЕМИАСе и ЕРИСе, уверенный пользователь ПК;</li><li>умение консультировать специалистов клинических дисциплин и пациентов, оперативность в работе, командная работа в коллективе, стрессоустойчивость, знание английского языка приветствуется.</li></ul><b>Условия:</b></p><p><ul><li>трудоустройство в соответствии с ТК РФ;</li><li>график работы: дневной, сменный, 30-ая рабочая неделя на 1,0 ставку;</li><li>заработная плата по результатам собеседования.</li><li>Для членов Профсоюза реализованы следующие проекты:</li><li>Медицинское сопровождение;</li><li>Созданы спортивные команды из числа членов ППО и работников ММКЦ «Коммунарка», принимающие участия в официальных соревнованиях от Департамента здравоохранения Москвы и Московской Федерации Профсоюзов;</li><li>Бесплатные занятия по Йоге;</li><li>Скидочная программа в столовой на территории ММКЦ «Коммунарка»;</li><li>Поездки на тематические экскурсии, курорты, Здравницы;</li><li>Льготная программа в детских оздоровительных лагерях;</li><li>Скидки и бесплатные билеты в театры, на мюзиклы, спектакли, при условии наличия специального предложения от организаторов;</li><li>Помощь при поступлении ребёнка в первый класс;</li><li>Помощь при принятии ребёнка в детский сад;</li><li>Участие в благотворительных мероприятиях.</li></ul>Ключевые навыки </p>',
                tags: [
                    {
                        id:1,
                        name:'Зарплата',
                        value:'10000 руб',
                        color:'danger',
                    },
                    {
                        id:2,
                        name:'Логистика',
                        value:'',
                        color:'',
                    },
                    {
                        id:3,
                        name:'Директор',
                        value:'',
                        color:'success',
                    }
                ]
            },
            {
                id:3,
                serviceId:'hh',
                serviceLogoUrl:'/hhLogo.png',
                inServiceId:3432,
                employer:'Яндекс',
                title:'Директор по логистике курьеров',
                description: '<p><b>Обязанности:</b></p><p><ul><li>проводит лучевые исследования в соответствии со стандартом медицинской помощи;</li><li>оформляет протоколы проведенных лучевых исследований по модальностям компьютерная томография(CT) и магнитно-резонансная томография(MR) с заключением о предполагаемом рентгенологическом диагнозе, необходимом комплексе уточняющих лучевых и других инструментальных исследований;</li><li>обеспечивает правильное и своевременное оформление медицинской и иной документации в соответствии с установленными правилами;</li><li>консультирует врачей других специальностей по вопросам обоснованного и рационального выбора лучевых исследований, оценивает динамику по результатам проведенных лучевых исследований с оформлением протокола, участвует в консилиумах, клинических разборах, клинико-диагностических конференциях.</li></ul><b>Требования:</b></p><p><ul><li>высшее образование - специалитет по одной из специальностей: \\"Лечебное дело\\", \\"Педиатрия\\" и подготовка в интернатуре и (или) ординатуре по специальности \\"Рентгенология\\", либо профессиональная переподготовка по специальности \\"Рентгенология\\" при наличии подготовки в интернатуре и (или) ординатуре по одной из специальностей: \\"Акушерство и гинекология\\", \\"Анестезиология-реаниматология\\", \\"Детская хирургия\\", \\"Детская онкология\\", \\"Детская эндокринология\\", \\"Гастроэнтерология\\", \\"Гематология\\", \\"Инфекционные болезни\\", \\"Кардиология\\", \\"Колопроктология\\", \\"Лечебная физкультура и спортивная медицина\\", \\"Нефрология\\", \\"Неврология\\", \\"Нейрохирургия\\", \\"Общая врачебная практика (семейная медицина)\\", \\"Онкология\\", \\"Оториноларингология\\", \\"Офтальмология\\", \\"Педиатрия\\", \\"Пульмонология\\", \\"Радиология\\", \\"Ревматология\\", \\"Рентгенэндоваскулярные диагностика и лечение\\", \\"Сердечно-сосудистая хирургия\\", \\"Скорая медицинская помощь\\", \\"Торакальная хирургия\\", \\"Терапия\\", \\"Травматология и ортопедия\\", \\"Ультразвуковая диагностика\\", \\"Урология\\", \\"Фтизиатрия\\", \\"Хирургия\\", \\"Эндокринология\\";</li><li>сертификат специалиста или свидетельство об аккредитации специалиста по специальности «Рентгенология»;</li><li>наличие сертификатов по повышению квалификации КТ и МРТ в онкологии;</li><li>наличие действующего удостоверения по радиационной безопасности;</li><li>знание КТ И МРТ в онкологии с опытом работы более 5 лет;</li><li>умение работать в ЕМИАСе и ЕРИСе, уверенный пользователь ПК;</li><li>умение консультировать специалистов клинических дисциплин и пациентов, оперативность в работе, командная работа в коллективе, стрессоустойчивость, знание английского языка приветствуется.</li></ul><b>Условия:</b></p><p><ul><li>трудоустройство в соответствии с ТК РФ;</li><li>график работы: дневной, сменный, 30-ая рабочая неделя на 1,0 ставку;</li><li>заработная плата по результатам собеседования.</li><li>Для членов Профсоюза реализованы следующие проекты:</li><li>Медицинское сопровождение;</li><li>Созданы спортивные команды из числа членов ППО и работников ММКЦ «Коммунарка», принимающие участия в официальных соревнованиях от Департамента здравоохранения Москвы и Московской Федерации Профсоюзов;</li><li>Бесплатные занятия по Йоге;</li><li>Скидочная программа в столовой на территории ММКЦ «Коммунарка»;</li><li>Поездки на тематические экскурсии, курорты, Здравницы;</li><li>Льготная программа в детских оздоровительных лагерях;</li><li>Скидки и бесплатные билеты в театры, на мюзиклы, спектакли, при условии наличия специального предложения от организаторов;</li><li>Помощь при поступлении ребёнка в первый класс;</li><li>Помощь при принятии ребёнка в детский сад;</li><li>Участие в благотворительных мероприятиях.</li></ul>Ключевые навыки </p>',
                tags: [
                    {
                        id:1,
                        name:'Зарплата',
                        value:'10000 руб',
                        color:'danger',
                    },
                    {
                        id:2,
                        name:'Логистика',
                        value:'',
                        color:'',
                    },
                    {
                        id:3,
                        name:'Директор',
                        value:'',
                        color:'success',
                    }
                ]
            }
        ],
        isLoading:false,
    }),
    actions:{
        async loadVanaciesByPromt({getters, commit},promt){
            commit('changeIsLoading',true)
            // setTimeout(()=>{
            //     commit('changeIsLoading',false)
            // },5000)
            console.log(getters.searchState.actualPrompt);
            try {
                const res = await axios.get('/api/Vacancy/search',{
                    params: {
                        prompt:getters.searchState.actualPrompt,
                    }
                })
                console.log(res.data);

                commit('changeVacations',res.data.objects)
            } catch (e){
                console.error(e)
            }
            commit('changeIsLoading',false)


        },
        newStart({commit}){
            commit('clear')
        }
    },
    mutations: {
        removeVac(state,id){
            state.vacancies = state.vacancies.filter(el=>el.id !== id);
        },
        changeVacations(state,vacs){
            state.vacancies = [];
            for (let i = 0; i < vacs.length; i++) {
                if(i>5) break;
                const vac = vacs[i];
                const tags = [];
                if(vac?.type_of_work.title.length>2){
                    tags.push({
                        id:1,
                        name:vac?.type_of_work.title,
                        value:'',
                        color:'success',
                    })
                }

                if(vac?.experience.title.length>2){
                    tags.push({
                        id:1,
                        name:vac?.experience.title,
                        value:'',
                        color:'success',
                    })
                }

                if(vac?.agency.title.length>2){
                    tags.push({
                        id:1,
                        name:vac?.agency.title,
                        value:'',
                        color:'success',
                    })
                }

                state.vacancies.push({
                    id:vac.id,
                    serviceId:'sj',
                    serviceLogoUrl:'/superjob_logo_180.png',
                    inServiceId:vac.id,
                    employer:'',
                    title:vac.profession,
                    description: vac.candidat,
                    tags
                })
            }

        },
        changeIsLoading(state,newVal){
            state.isLoading = newVal;
        },
        changeState(state,newStateData){
            if(newStateData.actualPrompt !== undefined) state.actualPrompt = newStateData.actualPrompt;
            if(newStateData.actualStep !== undefined) state.actualStep = newStateData.actualStep;
        },
        clear(state){
            state.actualPrompt = '';
            state.actualStep = 0;
            // state.vacancies = [];
        }
    },
    getters:{
        isLoading(state){
            return state.isLoading;
        },
        isValidPromptText(state){
            return state.actualPrompt.length < 125;
        },
        vacancies(state){
            return state.vacancies
        },
        searchState(state){
            return state;
        }
    }
}