<template>
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
        sm="12"
        md="12"
      >
        <v-card class="elevation-0">
          <v-card-text>
            <v-row
              align="center"
              justify="center"
            >
              <v-col class="text-right" cols="12" sm="12">
                <div class="my-2">
                  <v-dialog v-model="dialog" persistent max-width="600px">
                    <v-card>
                      <v-card-title>
                        <span class="headline">Criar Novo Álbum</span>
                      </v-card-title>
                      <v-card-text>
                        <v-container>
                          <v-row>
                            <v-col cols="12">
                              <v-text-field
                                v-model="nomeNovoAlbum"
                                label="Nome do Álbum"
                              />
                            </v-col>
                          </v-row>
                        </v-container>
                      </v-card-text>
                      <v-card-actions>
                        <v-spacer />
                        <v-btn @click="dialog = false" color="blue darken-1" text>
                          Cancelar
                        </v-btn>
                        <v-btn :disabled="!activeCriarButton" @click="dialog = false, criar()" color="blue darken-1" text>
                          Criar
                        </v-btn>
                      </v-card-actions>
                    </v-card>
                  </v-dialog>
                  <v-dialog v-model="dialogAtualizar" persistent max-width="600px">
                    <v-card>
                      <v-card-title>
                        <span class="headline">{{ `Atualizar Álbum` }}</span>
                      </v-card-title>
                      <v-card-text>
                        <v-container>
                          <v-row>
                            <v-col cols="12">
                              <v-text-field
                                v-model="albumAtualizado.nome"
                                label="Nome do Álbum"
                              />
                            </v-col>
                          </v-row>
                        </v-container>
                      </v-card-text>
                      <v-card-actions>
                        <v-spacer />
                        <v-btn @click="dialogAtualizar = false" color="blue darken-1" text>
                          Cancelar
                        </v-btn>
                        <v-btn :disabled="!activeAtualizarButton" @click="dialogAtualizar = false, atualizar()" color="blue darken-1" text>
                          Atualizar
                        </v-btn>
                      </v-card-actions>
                    </v-card>
                  </v-dialog>
                  <div v-if="getUser.perfilAcesso === 'Fotografo'">
                  <v-btn
                    @click.stop="dialog = true"
                    color="primary"
                    class="ma-2"
                    outlined
                  >
                    <v-icon left>
                      mdi-plus
                    </v-icon>
                    Criar Novo Álbum
                  </v-btn>
                  </div>
                </div>
              </v-col>
            </v-row>
            <v-row
              align="center"
              justify="left"
            >
              <v-col
                v-for="album in albuns"
                :key="album.id"
                :cols="12"
                sm="12"
                md="3"
              >
                <v-card
                  class="mx-auto"
                  max-width="344"
                >
                  <v-img
                    :src="images.album"
                    height="150px"
                  />

                  <v-card-title>
                    {{ album.nome }}
                  </v-card-title>

                  <v-card-subtitle>
                    {{ 'Criado em: ' + album.criadoEm }}
                  </v-card-subtitle>

                  <v-card-actions>
                    <v-spacer />
                    <v-btn
                      icon
                    >
                      <v-icon :to="`/album/${album.id}`"
                        tag="router-link"
                        small>
                        mdi-eye
                      </v-icon>
                    </v-btn>
                    <v-btn
                      @click.stop="dialogAtualizar = true, albumAtualizado.nome = album.nome, albumAtualizado.id = album.id"
                      icon
                    >
                      <v-icon small>
                        mdi-pencil
                      </v-icon>
                    </v-btn>
                    <v-btn
                      icon
                    >
                      <v-icon @click="deletar(album.id)" small>
                        mdi-delete
                      </v-icon>
                    </v-btn>
                  </v-card-actions>
                </v-card>
              </v-col>
            </v-row>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  //middleware: 'authenticated',
  data: () => ({
    albuns: [],
    dialog: false,
    dialogAtualizar: false,
    nomeNovoAlbum: '',
    albumAtualizado: {
      id: null,
      nome: ''
    },
    images: {
      album: require('@/static/album-compressed.png')
    }
  }),
  computed: {
    activeCriarButton () {
      return !!this.nomeNovoAlbum
    },
    getUser () {
      return this.$store.getters['usuario/GET_USER']
    },
    activeAtualizarButton(){
      return !!this.albumAtualizado.nome
    }
  },
  async created () {
   
    const data = await this.$store.dispatch('album/GET_ALBUNS')
    console.log(data)
    if (data) {
      this.albuns = this.$store.state.album.albuns
      console.log(this.albuns)
    }
  },
  methods: {
    async criar () {
      const payload = {
        nome: this.nomeNovoAlbum
      }
      const data = await this.$store.dispatch('album/POST_ALBUM', payload)
      if (data) {
        this.albuns = this.$store.state.album.albuns
      }
      this.nomeNovoAlbum = ''
    },
    async deletar (id) {
      const data = await this.$store.dispatch('album/DELETE_ALBUM', id)
      if (data) {
        this.albuns = this.$store.state.album.albuns
      }
    },
    async atualizar () {
      const payload = this.albumAtualizado
      const data = await this.$store.dispatch('album/PUT_ALBUM', payload)
      if (data) {
        this.albuns = this.$store.state.album.albuns
      }
    }
  }
}
</script>

<style>

</style>
