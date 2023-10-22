<template>
    <NavBar />
    <va-stepper
            v-model="actualStep"
            :steps="steps"
            controlsHidden
            class="stepper"
    >
        <template
            v-for="(step, i) in steps"
            :key="step.label"
            #[`step-button-${i}`]="{ setStep, isActive, isCompleted }"
        >
            <div
                @click="(i>actualStep)?setStep(i):null"
                class="step-button"
                :class="{
                  'step-button--active': isActive,
                  'step-button--completed': isCompleted,
                }"
            >
                <!--        -->
                <va-icon :name="step.icon" />
                {{ step.label }}
            </div>
        </template>
        <template #step-content-0>
            <AiPromptStep
                ref="aiPrompt"
            />
        </template>
<!--        <template #step-content-1>-->
<!--            <ConfirmFilters-->
<!--            />-->
<!--        </template>-->
        <template #step-content-1>
            <VacancyList
            />
        </template>
        <template #step-content-2>
            NEVER BE HERE (we redirect to reply route instead)
        </template>

        <template #controls="{ nextStep, prevStep, step }">
            <va-button
                    @click="handleNextButton(step,nextStep)"
                    :disabled="!isNextBtnAvailable(step)"
                    :loading="isLoading"
            >
                {{getNextButtonText(step)}}
            </va-button>
        </template>
    </va-stepper>
</template>

<script>
import NavBar from "../components/NavBar.vue";
import AiPromptStep from "./SearchRelated/AiPromptStep.vue";
import ConfirmFilters from "./SearchRelated/ConfirmFilters.vue";
import VacancyList from "./SearchRelated/VacancyList.vue";
import {mapActions, mapGetters, mapMutations} from "vuex";

export default {
    components: {
        VacancyList,
        ConfirmFilters,
        AiPromptStep,
        NavBar
    },
    watch: {
        actualStep:function (newValue){
            if(newValue === 2){
                this.$router.push('/reply');
            }
        }
    },
    mounted() {
        this.newStart()
    },
    data(){
        return {
            steps: [
                {
                    label: 'Запрос',
                    icon: 'list',
                },
                // { label: 'Фильтры', icon: 'check_box' },
                { label: 'Вакансии', icon: 'payments' },
                { label: 'Отклики', icon: 'done_all' },
            ]
        }
    },
    computed: {
        ...mapGetters('Search',[
            'isValidPromptText',
            'searchState',
            'isLoading'
        ]),
        actualStep: {
            get(){
                return this.searchState.actualStep;
            },
            set(value){
                this.changeState({
                    actualStep:value
                })
            }
        }
    },
    methods: {
        ...mapMutations('Search',[
            'changeState'
        ]),
        ...mapActions('Search',[
            'newStart',
            'loadVanaciesByPromt'
        ]),
        isNextBtnAvailable(step){
            if(step.icon === 'list') {
                return this.isValidPromptText;
            }
            return true;
        },
        getNextButtonText(step){
            if(step.icon === 'list') return 'Найти'
            return 'Дальше'
        },
        async handleNextButton(step,nextStepFunc){
            if(step.icon === 'list') {
                await this.loadVanaciesByPromt();
                // console.log(this.$refs.aiPrompt.validatePrompt())
                //call get specifications for search on external services (next step)
            }
            nextStepFunc();
        }
    }
}
</script>

<style scoped>
.step-button--active {
  color: var(--va-primary);
}
.step-button {
  //box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px;
  padding: 0.75rem;
  border-radius: .25rem;
  cursor: pointer;
  transition: .5s ease-in color;
}
.step-button:hover {
  color: var(--va-primary);
}
.step-button--completed {
  color: var(--va-success)
}
.stepper {
  margin-top: 1rem;
  overflow: auto;
    width: 100%;
}
.stepper-container{
    height: 60vh;
    overflow: auto;
}
</style>