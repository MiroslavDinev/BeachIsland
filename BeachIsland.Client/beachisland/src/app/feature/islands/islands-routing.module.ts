import { RouterModule, Routes } from "@angular/router";
import { AdminIslandComponent } from "./admin-island/admin-island.component";
import { CreateislandComponent } from "./createisland/createisland.component";
import { EditIslandComponent } from "./edit-island/edit-island.component";
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
    },
    {
        path: 'islands/:id/update',
        component: EditIslandComponent
    },
    {
        path: 'admin/islands',
        component: AdminIslandComponent
    }
]

export const IslandsRoutingModule = RouterModule.forChild(routes);