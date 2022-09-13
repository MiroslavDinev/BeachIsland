import { RouterModule, Routes } from "@angular/router";
import { CreateislandComponent } from "./createisland/createisland.component";

const routes: Routes =[
    {
        path: 'islands/add',
        component: CreateislandComponent
    }
]

export const IslandsRoutingModule = RouterModule.forChild(routes);