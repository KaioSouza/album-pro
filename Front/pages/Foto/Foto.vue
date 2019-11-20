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
              <v-col class="text-left" cols="6" sm="6">
                <div class="my-2">
                  <div class="display-1">
                    <span>
                      Nome do Álbum
                    </span>
                  </div>
                </div>
              </v-col>
              <v-col class="text-right" cols="6" sm="6">
                <div class="my-2">
                  <v-dialog v-model="dialog" persistent max-width="600px">
                    <v-card>
                      <v-card-title>
                        <span class="headline">Envio de Foto(s)</span>
                      </v-card-title>
                      <v-card-text>
                        <v-container>
                          <v-row>
                            <v-col cols="12">
                              <v-file-input
                                v-model="files"
                                :show-size="1000"
                                color="deep-purple accent-4"
                                counter
                                label="Envio"
                                multiple
                                placeholder="Selecione as fotos"
                                prepend-icon="mdi-paperclip"
                                outlined
                              >
                                <template v-slot:selection="{ index, text }">
                                  <v-chip
                                    v-if="index < 2"
                                    color="deep-purple accent-4"
                                    dark
                                    label
                                    small
                                  >
                                    {{ text }}
                                  </v-chip>

                                  <span
                                    v-else-if="index === 2"
                                    class="overline grey--text text--darken-3 mx-2"
                                  >
                                    +{{ files.length - 2 }} File(s)
                                  </span>
                                </template>
                              </v-file-input>
                            </v-col>
                          </v-row>
                        </v-container>
                        <small>Tamanho total máximo permitido: 1mb</small>
                      </v-card-text>
                      <v-card-actions>
                        <v-spacer />
                        <v-btn @click="dialog = false" color="blue darken-1" text>
                          Cancelar
                        </v-btn>
                        <v-btn @click="dialog = false" color="blue darken-1" text>
                          Enviar
                        </v-btn>
                      </v-card-actions>
                    </v-card>
                  </v-dialog>
                  <v-btn
                    @click.stop="dialog = true"
                    color="primary"
                    class="ma-2"
                    outlined
                  >
                    <v-icon left>
                      mdi-plus
                    </v-icon>
                    Adicionar Foto
                  </v-btn>
                </div>
              </v-col>
            </v-row>
            <v-row
              align="center"
              justify="center"
            >
              <v-col
                v-for="card in cards"
                :key="card.title"
                :cols="3"
                sm="3"
                md="3"
              >
                <v-card
                  class="mx-auto"
                  max-width="344"
                >
                  <v-img
                    src="https://cdn.vuetifyjs.com/images/cards/sunshine.jpg"
                    height="200px"
                  />

                  <v-card-title>
                    Nome da Foto
                  </v-card-title>

                  <v-card-subtitle>
                    Adicionada em 12/12/2019
                  </v-card-subtitle>

                  <v-card-actions>
                    <v-spacer />
                    <v-btn
                      icon
                    >
                      <v-icon small>
                        mdi-eye
                      </v-icon>
                    </v-btn>
                    <v-btn
                      icon
                    >
                      <v-icon small>
                        mdi-pencil
                      </v-icon>
                    </v-btn>
                    <v-btn
                      icon
                    >
                      <v-icon small>
                        mdi-delete
                      </v-icon>
                    </v-btn>
                  </v-card-actions>
                </v-card>
              </v-col>
            </v-row>
            <v-row
              align="center"
              justify="center"
            >
              <v-col
                cols="3"
                sm="3"
                md="3"
              >
                <v-card class="elevation-2">
                  <v-card-text>
                    <br>
                    <br>
                    <br>
                  </v-card-text>
                </v-card>
              </v-col>
              <v-col
                cols="3"
                sm="3"
                md="3"
              >
                <v-card class="elevation-2">
                  <v-card-text>
                    <br>
                    <br>
                    <br>
                  </v-card-text>
                </v-card>
              </v-col>
              <v-col
                cols="3"
                sm="3"
                md="3"
              >
                <v-card class="elevation-2">
                  <v-card-text>
                    <br>
                    <br>
                    <br>
                  </v-card-text>
                </v-card>
              </v-col>
              <v-col
                cols="3"
                sm="3"
                md="3"
              >
                <v-card class="elevation-2">
                  <v-card-text>
                    <br>
                    <br>
                    <br>
                  </v-card-text>
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
  data: () => ({
    files: [],
    dialog: false,
    cards: [
      {
        title: 'Pre-fab homes',
        src: 'https://cdn.vuetifyjs.com/images/cards/house.jpg',
        flex: 3
      },
      {
        title: 'Favorite road trips',
        src: 'https://cdn.vuetifyjs.com/images/cards/road.jpg',
        flex: 3
      },
      {
        title: 'Pre-fab homes',
        src: 'https://cdn.vuetifyjs.com/images/cards/house.jpg',
        flex: 3
      },
      {
        title: 'Favorite road trips',
        src: 'https://cdn.vuetifyjs.com/images/cards/road.jpg',
        flex: 3
      }
    ]
  })
}
</script>

<style>

</style>
