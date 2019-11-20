<template>
<div id="app">
  <v-app id="inspire">
  <v-container
    class="fill-height"
    fluid
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
            <v-toolbar-title>Cadastro</v-toolbar-title>
            <v-spacer />
          </v-toolbar>
          <v-card-text>
            <v-form>
              <v-text-field
                label="Nome Completo"
                name="login"
                v-model="form.nome"
                type="text"
                prepend-icon="mdi-account"
              />
              <v-text-field
                label="E-mail"
                name="login"
                v-model="form.email"
                type="text"
                prepend-icon="mdi-email"
              />

              <v-text-field
                label="Nome de Usuário(a)"
                name="login"
                v-model="form.userName"
                type="text"
                prepend-icon="mdi-account-circle"
              />
              <v-select
                :items="items"
                label="Perfil de Acesso"
                v-model="form.perfil"
                prepend-icon="mdi-account"
              />
              <v-text-field
                id="password"
                label="Senha"
                name="password"
                v-model="form.senha"
                type="password"
                prepend-icon="mdi-key"
              />
              <v-text-field
                id="password"
                label="Repita a Senha"
                name="password"
                type="password"
                v-model="form.repitaSenha"
                prepend-icon="mdi-key"
              />
            </v-form>
          </v-card-text>
          <v-card-actions>
            <v-spacer />
            <v-btn :disabled="!activeCadastrarButton" @click="cadastrar()" color="primary">
              Cadastrar
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
  </v-app>
</div>
</template>

<script>
export default {
  data: () => ({
    items: ['Cliente', 'Fotografo'],
    form: {
      nome: '',
      email: '',
      senha: '',
      perfil: '',
      repitaSenha: '',
      userName: ''
    }
  }),
  computed: {
    activeCadastrarButton () {
      return !!this.form.nome 
        && !!this.form.email
        && !!this.form.senha
        && !!this.form.perfil
        && !!this.form.userName 
        && this.form.repitaSenha === this.form.senha
    }
  },
  methods: {
    async cadastrar(){
      const result = await this.$store.dispatch('usuario/CADASTRAR', this.form)

      if (result) {
        this.$router.push({ path: '/' })
      }
    }
  }
}
</script>

<style>

</style>
