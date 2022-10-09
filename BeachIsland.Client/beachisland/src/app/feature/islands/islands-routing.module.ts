import { RouterModule, Routes } from "@angular/router";
import { AdminGuard } from "src/app/core/guards/admin.guard";
import { AuthGuard } from "src/app/core/guards/auth.guard";
import { EditGuard } from "src/app/core/guards/edit.guard";
import { PartnerGuard } from "src/app/core/guards/partner.guard";
import { ContactPageComponent } from "../pages/contact-page/contact-page.component";
import { AdminIslandComponent } from "./admin-island/admin-island.component";
import { CreateislandComponent } from "./createisland/createisland.component";
import { EditIslandComponent } from "./edit-island/edit-island.component";
import { IslandDetailsComponent } from "./island-details/island-details.component";
import { ListIslandsComponent } from "./list-islands/list-islands.component";
import { PartnerIslandsComponent } from "./partner-islands/partner-islands.component";

const routes: Routes =[
    {
        path: 'islands',
        component: ListIslandsComponent
    },
    {
        path: 'islands/add',
        component: CreateislandComponent,
        canActivate: [PartnerGuard]
    },
    {
        path: 'islands/:id',
        component: IslandDetailsComponent
    },
    {
        path: 'islands/:id/update',
        component: EditIslandComponent,
        canActivate: [EditGuard]
    },
    {
        path: 'islands/:id/contact/book',
        component: ContactPageComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'admin/islands',
        component: AdminIslandComponent,
        canActivate: [AdminGuard]
    },
    {
        path: 'partner/islands',
        component: PartnerIslandsComponent,
        canActivate: [PartnerGuard]
    }
]

export const IslandsRoutingModule = RouterModule.forChild(routes);