<template>
  <v-app>
    <div>
      <div v-if="hasUser">
        <v-app-bar
          color="primary"
          dark
        >
          <v-btn icon>
            <v-icon>mdi-image</v-icon>
          </v-btn>

          <v-toolbar-title>Awesome Álbum</v-toolbar-title>

          <v-spacer />

          <div>
            <v-toolbar-title>{{ getUser.nomeCompleto }}</v-toolbar-title>
          </div>
          <v-btn icon>
            <v-icon @click="sair">
              mdi-exit-to-app
            </v-icon>
          </v-btn>
        </v-app-bar>
      </div>
        <v-overlay :value="isLoading">
          <v-progress-circular indeterminate size="64"></v-progress-circular>
      </v-overlay>
      <v-content>
        <v-container>
          <nuxt />
        </v-container>
      </v-content>
    </div>
  </v-app>
</template>

<script>
export default {
  computed: {
    hasUser () {
      return this.$store.getters['usuario/USER_LOGGED_IN']
    },

    getUser () {
      return this.$store.getters['usuario/GET_USER']
    },
     isLoading () {
      return this.$store.state.global.isLoading
    },
  },
  methods: {
    go () {
      this.$router.go(-1)
    },
    sair () {
      this.$store.dispatch('usuario/SET_USER_APP', null)
      this.$router.push('/')
    }
  }
}
</script>
