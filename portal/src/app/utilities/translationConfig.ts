import {TranslateService } from '@ngx-translate/core';
import { LanguageConstants } from '../models/Constants/languageConstants';
import { ActivatedRoute } from '@angular/router';


export class TranslationUtil{
    translationDirection: {[key:string]:string} = {}

    constructor(private translateService: TranslateService)
    {
    }

    initConfig(){
        this.translateService.addLangs([LanguageConstants.DK, LanguageConstants.EN]);
        this.translateService.setDefaultLang(LanguageConstants.EN);
    }

    set translationLanguage(lang: string){
        this.translateService.use(lang)
    }
}

