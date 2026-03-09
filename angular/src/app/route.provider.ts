import { RoutesService, eLayoutType } from '@abp/ng.core';
import { inject, provideAppInitializer } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routes = inject(RoutesService);
  routes.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
       {
      path: '/marquee-management',
      name: '::Menu:MarqueeManagement',
      iconClass: 'fas fa-building',
      order: 2,
      layout: eLayoutType.application,
    },
    {
      path: '/marquees',
      name: '::Menu:Marquees',
      iconClass: 'fas fa-warehouse', 
      parentName: '::Menu:MarqueeManagement',
      layout: eLayoutType.application,
      requiredPolicy: 'MarqueeManagement.Marquees',
    },
    {
      path: '/customers',
      name: '::Menu:Customers',
      parentName: '::Menu:MarqueeManagement',
       iconClass: 'fas fa-users',
      layout: eLayoutType.application,
      requiredPolicy: 'MarqueeManagement.Customers',
    },
    {
      path: '/menu-items',
      name: '::Menu:MenuItems',
      iconClass: 'fas fa-utensils',
      parentName: '::Menu:MarqueeManagement',
      layout: eLayoutType.application,
      requiredPolicy: 'MarqueeManagement.MenuItems',
    },

     {
      path: '/bookings',
      name: '::Menu:Bookings',
      iconClass: 'fas fa-calendar-check',
      parentName: '::Menu:MarqueeManagement',
      layout: eLayoutType.application,
      requiredPolicy: 'MarqueeManagement.Bookings',
    },
    {
      path: '/menu-categories',
      name: '::Menu:MenuCategories',
      iconClass: 'fas fa-list-alt',
      parentName: '::Menu:MarqueeManagement',
      layout: eLayoutType.application,
      requiredPolicy: 'MarqueeManagement.MenuCategories',
    },

  ]);
}
