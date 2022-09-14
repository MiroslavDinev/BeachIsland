import { RouterModule, Routes } from "@angular/router";
import { CreateislandComponent } from "./createisland/createisland.component";
import { ListIslandsComponent } from "./list-islands/list-islands.component";

const routes: Routes =[
    {
        path: 'islands',
        component: ListIslandsComponent
    },
    {
        path: 'islands/add',
        component: CreateislandComponent
    }
]

export const IslandsRoutingModule = RouterModule.forChild(routes);