import { Component, OnDestroy, OnInit, Output, signal, WritableSignal } from "@angular/core";
import { ModuleService } from "../../../common/services/module.service";
import { ModuleModel } from "./module.model";
import { SvgIconComponent } from "../../../common/components/svg-icon/svg-icon.component";
import { ActivatedRoute, Router, RouterLink, RouterLinkActive } from "@angular/router";

@Component({
    selector: 'module-list',
    templateUrl: './module-list.component.html',
    styleUrl: './module-list.component.css',
    imports: [RouterLink, RouterLinkActive]
})
export class ModuleListComponent implements OnInit{
    modules:WritableSignal<ModuleModel[]> = signal([]);
    constructor(private moduleService: ModuleService){

    }

    ngOnInit(): void {
        this.moduleService.getModules().subscribe((response)=>{
            debugger;
            this.modules.set(response.modules);
        });
    }

    onModuleChange(moduleId: number): void{

    }
}