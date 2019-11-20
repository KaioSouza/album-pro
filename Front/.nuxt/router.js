import Vue from 'vue'
import Router from 'vue-router'
import { interopDefault } from './utils'
import scrollBehavior from './router.scrollBehavior.js'

const _d74e11a4 = () => interopDefault(import('..\\pages\\Cadastro.vue' /* webpackChunkName: "pages_Cadastro" */))
const _7c35d275 = () => interopDefault(import('..\\pages\\Album\\Album.vue' /* webpackChunkName: "pages_Album_Album" */))
const _7807f3e0 = () => interopDefault(import('..\\pages\\Album\\_id.vue' /* webpackChunkName: "pages_Album__id" */))
const _a70c6a66 = () => interopDefault(import('..\\pages\\index.vue' /* webpackChunkName: "pages_index" */))

Vue.use(Router)

export const routerOptions = {
  mode: 'history',
  base: decodeURI('/'),
  linkActiveClass: 'nuxt-link-active',
  linkExactActiveClass: 'nuxt-link-exact-active',
  scrollBehavior,

  routes: [{
    path: "/Cadastro",
    component: _d74e11a4,
    name: "Cadastro"
  }, {
    path: "/Album/Album",
    component: _7c35d275,
    name: "Album-Album"
  }, {
    path: "/Album/:id?",
    component: _7807f3e0,
    name: "Album-id"
  }, {
    path: "/",
    component: _a70c6a66,
    name: "index"
  }],

  fallback: false
}

export function createRouter () {
  return new Router(routerOptions)
}
