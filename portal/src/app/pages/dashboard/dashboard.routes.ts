import { Routes } from "@angular/router";
import { UsersComponent } from "./users/users.component";

export const DASHBOARD_ROUTES:Routes = [
    {path: "", pathMatch: "full", redirectTo: "dashboard/users"},
    {path: "users", component: UsersComponent}
]