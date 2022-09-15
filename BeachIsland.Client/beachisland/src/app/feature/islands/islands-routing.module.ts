import { RouterModule, Routes } from "@angular/router";
import { CreateislandComponent } from "./createisland/createisland.component";
import { IslandDetailsComponent } from "./island-details/island-details.component";
import { ListIslandsComponent } from "./list-islands/list-islands.component";

const routes: Routes =[
    {
        path: 'islands',
        component: ListIslandsComponent
    },
    {
        path: 'islands/add',
        component: CreateislandComponent
    },
    {
        path: 'islands/:id',
        component: IslandDetailsComponent
    }
]

export const IslandsRoutingModule = RouterModule.forChild(routes);