import { RouterModule, Routes } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { PartnerComponent } from "./partner/partner.component";
import { ProfileComponent } from "./profile/profile.component";
import { RegisterComponent } from "./register/register.component";

const routes: Routes = [
    {
        path: 'register',
        component: RegisterComponent
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'partner',
        component: PartnerComponent
    },
    {
        path: 'profile',
        component: ProfileComponent
    }
]

export const AuthRoutingModule = RouterModule.forChild(routes);