import { HttpClient, HttpParams } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { ModuleModel } from "../../pages/home/module/module.model";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class ModuleService {
    private httpClient: HttpClient = inject(HttpClient);
    
    constructor(){

    }

    getModules(): Observable<{modules: ModuleModel[]}>{
        return this.httpClient.get<{modules: ModuleModel[]}>('http://localhost:5135/Module/GetModules');
    }
}