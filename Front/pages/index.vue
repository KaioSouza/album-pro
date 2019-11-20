<template>
<div id="app">
  <v-app id="inspire">
  <v-container
      fluid
      fill-height
  >
  <v-layout
    align-center
    justify-center
    >
    <v-row
      align="center"
      justify="center"
    >
      <v-col
        cols="12"
        sm="8"
        md="4"
      >
        <v-card class="elevation-12">
          <v-toolbar
            color="primary"
            dark
            flat
          >
            <v-toolbar-title>Login</v-toolbar-title>
            <v-spacer />
          </v-toolbar>
          <v-card-text>
            <v-form>
              <v-select
                :items="items"
                label="Perfil de Acesso"
                prepend-icon="mdi-account"
              />
              <v-text-field
                v-model="nomeUsuario"
                label="Usuário(a)"
                name="login"
                type="text"
                prepend-icon="mdi-account-circle"
              />

              <v-text-field
                id="password"
                v-model="senha"
                label="Senha"
                name="password"
                type="password"
                prepend-icon="mdi-key"
              />
            </v-form>
          </v-card-text>
          <v-card-actions>
            <v-spacer />
            <v-btn
             tag="router-link"
                :to="`/cadastro`"
              color="secondary"
            >
              Cadastrar
            </v-btn>
            <v-btn
              @click="login"
              :disabled="!activeLoginButton"
              color="primary"
            >
              Login
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-layout>
  </v-container>
  </v-app>
  </div>
</template>

<script>

export default {
  data: () => ({
    items: ['Cliente', 'Fotografo'],
    nomeUsuario: '',
    senha: ''
  }),
  computed: {
    activeLoginButton () {
      return !!this.nomeUsuario && !!this.senha
    }
  },
  methods: {
    async login () {
      const user = {
        userName: this.nomeUsuario,
        senha: this.senha
      }
      const result = await this.$store.dispatch('usuario/LOGIN', user)

      if (result) {
        this.$router.push({ name: 'Album-Album' })
      }
    }
  }
}
</script>
