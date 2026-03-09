import { authGuard, permissionGuard } from '@abp/ng.core';
import { Routes } from '@angular/router';

export const APP_ROUTES: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadComponent: () => import('./home/home.component').then(c => c.HomeComponent),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(c => c.createRoutes()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(c => c.createRoutes()),
  },
  {
    path: 'tenant-management',
    loadChildren: () => import('@abp/ng.tenant-management').then(c => c.createRoutes()),
  },
  {
    path: 'setting-management',
    loadChildren: () => import('@abp/ng.setting-management').then(c => c.createRoutes()),
  },
{
  path: 'marquees',
  loadComponent: () => import('./marquees/marquees').then(c => c.Marquees),
},
{
  path: 'customers',
  loadComponent: () => import('./customers/customers').then(c => c.Customers),
},
{
  path: 'menu-items',
  loadComponent: () => import('./menu-items/menu-items').then(c => c.MenuItems),
},
{
  path: 'bookings',
  loadComponent: () => import('./bookings/bookings').then(c => c.Bookings),
},
{
  path: 'menu-categories',
  loadComponent: () => import('./menu-categories/menu-categories').then(c => c.MenuCategories),
},


];
